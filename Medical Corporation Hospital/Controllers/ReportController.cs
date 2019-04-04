using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Persistence;

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
            var hospital = _context.Hospitals
                .Include("City")
                .Include("Wards")
                .Include("Doctors")
                .Where(h => h.Name.Contains(name));
            return View(hospital);
        }
    }
}