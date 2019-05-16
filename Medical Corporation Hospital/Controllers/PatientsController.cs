using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class PatientsController : Controller
    {
        private readonly HospitalDbContext _context;

        public PatientsController()
        {
            _context = new HospitalDbContext();
        }
        // GET: Patients
        public ActionResult New()
        {
            var hospital = _context.Hospitals.ToList();
            var ward = _context.Wards.ToList();
            var bed = _context.Beds.ToList();

            var viewModel = new PatientViewModel
            {
                Patient = new Patient(),
                Hospitals = hospital,
                wards = ward,
                Beds = bed,

            };
            return View("PatientForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Patient patient)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PatientViewModel
                {
                    Patient = patient,
                    Beds = _context.Beds.ToList(),
                    Hospitals = _context.Hospitals.ToList(),
                    wards = _context.Wards.ToList()
                };
                return View("PatientForm", viewModel);
            }
            else
            {


                if (patient.Id == 0)
                {

                    var wardId = patient.WardId;
                    var bed = _context.Beds.First(b => b.WardId == wardId && b.Occupied == "No");


                    var bedInDbId = bed.Id;

                    patient.Bed = bed;
                    var bedInDb = _context.Beds.FirstOrDefault(b => b.Id == bedInDbId);
                    bedInDb.Occupied = "Yes";


                    _context.Patients.Add(patient);
                }

                else
                {
                    var patientInDb = _context.Patients.Single(p => p.Id == patient.Id);

                    patientInDb.FullName = patient.FullName;
                    patientInDb.Address = patient.Address;
                    patientInDb.Telephone = patient.Telephone;
                    patientInDb.AdmissionTime = patient.AdmissionTime;
                    patientInDb.HospitalId = patient.HospitalId;
                    patientInDb.WardId = patient.WardId;
                }

                _context.SaveChanges();


                return RedirectToAction("Patients", "Display");
            }
        }

        public ActionResult Edit(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient == null)
            {
                return HttpNotFound();
            }

            var viewModel = new PatientViewModel
            {
                Patient = patient,
                Hospitals = _context.Hospitals.ToList(),
                wards = _context.Wards.ToList(),
                Beds = _context.Beds.ToList()

            };
            return View("PatientForm", viewModel);
        }

        public ActionResult Remove(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

            if (patient != null)
            {
                patient.Hospital = null;
                patient.Ward = null;
                patient.Bed = null;
                patient.Doctors = null;
                //  patient = null;
                _context.Patients.Remove(patient);
            }


         
            _context.SaveChanges();

            return RedirectToAction("Patients", "Display");
        }
    }
}