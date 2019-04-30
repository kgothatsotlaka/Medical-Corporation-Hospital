using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly HospitalDbContext _context;
        //  protected readonly HospitalDbContext _context;

        public AppointmentsController( HospitalDbContext context)
        {
            _context = context;
            //   _context = new HospitalDbContext();
        }
      
        public ActionResult Index()
        {
            

            var appointments = _context.Hospitals.Include(h => h.Doctors).Include(h => h.Patients).ToList();

            

            return View(appointments);
        }

        public ActionResult New()
        {
            var doctors = _context.Doctors.Include(d => d.Hospitals).Include(d => d.Patients).ToList();
            var patients = _context.Patients.Include(p => p.Hospital).Include(p => p.Doctors).ToList();
            var hospitals = _context.Hospitals.Include(h => h.Doctors).Include(h => h.Patients).ToList();

            var viewModel = new AppointmentsViewModel
            {
                Doctors = doctors,
                Patients = patients,
                Hospitals = hospitals
            };

            return View("AppointmentForm", viewModel);
        }
    }
}