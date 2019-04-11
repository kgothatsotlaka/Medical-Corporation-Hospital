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
        protected readonly HospitalDbContext _context;

        public AppointmentsController()
        {
            _context = new HospitalDbContext();
        }
        // GET: Appointments
        public ActionResult New()
        {
            var doctors = _context.Doctors.Include(d => d.Patients).Single();

           var patients = _context.Patients.Include(p=>p.Doctors).ToList();

            var viewModel = new AppointmentsViewModel
            {
                Doctor = doctors,
                Patients = patients
            };

            return View("AppointmentForm",viewModel);
        }
    }
}