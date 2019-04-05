using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
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
            
            var hospital = _context.Hospitals.Single(h => h.Name.Contains(name));
           
            var hospitalId = hospital.Id;


            var hospitalCityId = hospital.CityId;
            var city = _context.Cities.Single(c => c.Id == hospitalCityId);


            var wards = _context.Wards.Include(w=>w.Beds).Where(w => w.HospitalId == hospitalId);

          //  var worksAt = _context.Doctors.Include(h => h.Hospitals).Where(h => h.Hospitals.Contains(d=>d.Id == hospitalId);

          var worksAt = _context.Hospitals.Include(h => h.Doctors).Where(h => h.Id == hospitalId).ToList();

            var hospitalDetails = new HospitalDetailsViewModel
            {
                Hospital = hospital,
                City = city,
                Wards = wards,
                WorksAt =  worksAt
               


            };

            return View(hospitalDetails );
        }
    }
}