using System.Web.Mvc;
using Medical_Corporation_Hospital.Core;
using System;
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
                                            .Include("Wards")
                                            .Include("City")
                                            .Include("Patients")
                                            .Include("Doctors")
                                            .ToList();
            

            var wards = _context.Wards.Include("Hospital");

           // var wardsId = wards.W
            //hospitals.Include()
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