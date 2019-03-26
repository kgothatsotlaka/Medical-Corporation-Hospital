using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Models;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class HospitalsController : Controller
    {
        // GET: Hospitals/DisplayHospitals
        public ActionResult DisplayHospitals()
        {
//            var hospital = new List<Hospital>
//            {
//               new Hospital{Name="Steve Biko"},
//               new Hospital{Name="MulMed"},
//
//            };
//            var wards = new List<Ward>
//            {
//                new Ward{WardName="A"},
//                new Ward{WardName="B"},
//                new Ward{WardName="C"},
//            };
//
//            var hosiptalDetails = new HospitalDetailsViewModel
//            {
//                hospital = hospital,
//                ward = wards
//            };

            return View();
        }

//        public ActionResult DisplayBeds()
//        {
//            var hospital = new Hospitals() { Name = "Steve Biko" };
//            return View(hospital);
//        };
//        public ActionResult DisplayBeds()
//        {
//            return View();
//        };


    }
}