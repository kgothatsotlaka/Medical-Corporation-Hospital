using System.Web.Mvc;
using Medical_Corporation_Hospital.Core;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;

namespace Medical_Corporation_Hospital.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display

        //  private readonly IUnitOfWork _unitOfWork;
        private readonly HospitalDbContext _context;


        public DisplayController()
        {
            _context = new HospitalDbContext();
        }


        public ActionResult Hospitals()
        {
            var hospitals = _context.Hospitals
                .Include(h=>h.Wards)
                .Include(h=>h.City)
                .Include(h=>h.Patients)
                .Include(h=>h.Doctors)
                .ToList();


           
            return View(hospitals);
        }


        public ActionResult Wards()
        {
            var wards = _context.Wards
                .Include(w => w.Hospital)
                .Include(w => w.Beds)
                .Include(w => w.Patients)
                .ToList();

            return View(wards);
        }

        public ActionResult Beds()
        {
            var bed = _context.Beds
                .Include(b => b.Ward)
                .Include(b => b.Hospital)
                .Include(b => b.Patient)
                .ToList();

            return View(bed);
        }

        public ActionResult Cities()
        {
            var city = _context.Cities.Include(c => c.Hospitals).ToList();

            return View(city);
        }
    }
}