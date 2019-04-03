using System.Web.Mvc;
using Medical_Corporation_Hospital.Core;
using System;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Controllers
{
    public class DisplayController : Controller
    {
        // GET: Display

        private readonly IUnitOfWork _unitOfWork;

        
        public DisplayController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       

        public ActionResult Index()
        {
            var hospitals = _unitOfWork.Hospitals.GetAll();
            return View(hospitals);

           
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