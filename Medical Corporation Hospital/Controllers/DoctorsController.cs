using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        private HospitalDbContext _context;

        public DoctorsController()
        {
            _context = new HospitalDbContext();
        }
        public ActionResult New()
        {
            var hospitals = _context.Hospitals.ToList();
            var patients = _context.Patients.ToList();

            var viewModel = new DoctorViewModel
            {
                Hospitals = hospitals,
                Patients = patients
            };
            return View("DoctorForm",viewModel);
        }

        public ActionResult Save(Doctor doctor)
        {
            if (doctor.Id == 0)
            {
                doctor.Hospitals = null;
                doctor.Patients = null;
                _context.Doctors.Add(doctor);
            }
            else
            {
                var doctorInDb = _context.Doctors.Single(d => d.Id == doctor.Id);

                doctorInDb.Initials = doctor.Initials;
                doctorInDb.LastName = doctor.LastName;
                doctorInDb.Address = doctor.Address;
                doctorInDb.Telephone = doctor.Telephone;





            }

            _context.SaveChanges();

            return RedirectToAction("Doctors", "Display");
        }

        public ActionResult Edit(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return HttpNotFound();
            }

            var viewModel = new DoctorViewModel
            {
                doctor = doctor,
                Hospitals = _context.Hospitals.ToList(),
                Patients = _context.Patients.ToList()
            };

            return View("DoctorForm", viewModel);
        }
    }
}