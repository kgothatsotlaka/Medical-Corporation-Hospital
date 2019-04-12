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

            _context.SaveChanges();

            return RedirectToAction("Doctors", "Display");
        }
    }
}