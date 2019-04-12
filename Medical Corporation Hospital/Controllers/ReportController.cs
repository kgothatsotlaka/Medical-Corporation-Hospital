using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class ReportController : Controller
    {
        private readonly HospitalDbContext _context;
        // GET: Report

        public ReportController()
        {
            _context = new HospitalDbContext();
        }

       
        public ActionResult Hospital(string name = "Mediclinic Muelmed")
        {
            //Hospital
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Name.Contains(name));
            if (hospital == null)
            {
                return HttpNotFound();
            }
            var hospitalId = hospital.Id;

            //City
            // One City-Many Hospitals
            var hospitalCityId = hospital.CityId; //Doctor Entity has CityId property
            var city = _context.Cities.Single(c => c.Id == hospitalCityId);

            //Wards
            //One Hospital- Many Wards
            //Join Wards with Beds 
            var wards = _context.Wards
                                .Include(w=>w.Beds)
                                .Where(w => w.HospitalId == hospitalId);

         
            //Doctor
            //Many hospital- Many Doctors
            //In this case, One Hospital - Many Doctors

            var worksAt = _context.Hospitals
                                        .Include(h => h.Doctors)
                                        .Where(h => h.Id == hospitalId)
                                        .ToList();

            var hospitalDetails = new HospitalDetailsViewModel
            {
                Hospital = hospital,
                City = city,
                Wards = wards,
                WorksAt =  worksAt
               


            };

            return View(hospitalDetails );
        }

        public ActionResult Patient(string name= "Jacob Zuma")
        {
            var patient = _context.Patients.Single(p => p.FullName.Contains(name));
            var patientId = patient.Id;

            var appointments = _context.Patients.Include(p => p.Doctors).Where(p => p.Id == patientId).ToList();

            

            var patientHospitalId = patient.HospitalId;
            var admitted = _context.Hospitals.Single(h => h.Id == patientHospitalId);

            var patientWardId = patient.WardId;
            var patientward = _context.Wards.Single(w => w.Id == patientWardId);

            var patientBedId = patient.Bed;
            var patientBed = _context.Beds.First(b => b.Occupied.Contains("Yes"));


            var patientDetails = new PatientDetailsViewModel
            {
                Patient = patient,
                Appointments = appointments,
                Hospital = admitted,
                Ward = patientward,
                Bed =patientBed
            };

            return View(patientDetails);
        }

        public ActionResult Doctor(string lastName = "Ledwaba")
        {
            var doctor = _context.Doctors.Single(d => d.LastName.Contains(lastName));
            var doctorId = doctor.Id;

            var patients = _context.Doctors
                .Include(d => d.Patients)
                .Where(d => d.Id == doctorId).ToList();
                                      

            var doctorDetails = new DoctorDetailsViewModel
            {
                Doctor = doctor,
                Patients = patients

            };

             
            return View(doctorDetails);
        }
    }
}