using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Models;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display
        public ActionResult Hospitals()
        {
//            var myHospitals = new List<Hospital>
//            {
//                new Hospital{City="Pretoria",Id=1, NoOfDoctors = 5, NoOfPatients = 15, Name = "Steve Biko"},
//                new Hospital{City="Pretoria",Id=2, NoOfDoctors = 7, NoOfPatients = 20, Name = "Tshwane Hospital"},
//                new Hospital{City="Pretoria",Id=3, NoOfDoctors = 5, NoOfPatients = 21, Name = "Tuks Dental Hospital"},
//            };

//            var HopitalList = new HospitalDetailsViewModel {hospital = myHospitals};
           
            return View();
        }
        public ActionResult Wards()
        {
//            var myWards = new List<Ward>
//            {
//                new Ward{HospitalName = "Steve Biko", WardName = "BC", WardId = 1, NoOfBeds = 7},
//                new Ward{HospitalName = "Steve Biko", WardName = "A", WardId = 2, NoOfBeds = 8},
//            };
//            var WardList = new HospitalDetailsViewModel {ward = myWards};
//           
//                
//              
//
//            
            return View();
        }
    }
}