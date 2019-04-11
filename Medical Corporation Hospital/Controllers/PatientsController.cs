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
    public class PatientsController : Controller
    {
        protected readonly HospitalDbContext _context;

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
                Hospitals = hospital,
                wards = ward,
                Beds = bed,

            };
            return View("PatientForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Patient patient)
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

            _context.SaveChanges();


            return RedirectToAction("Patients", "Display");
        }
    }
}