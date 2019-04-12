using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class BedController : Controller
    {
        private readonly HospitalDbContext _context;

        public BedController()
        {
            _context = new HospitalDbContext();
        }
        // GET: Bed
        public ActionResult New()
        {
            var hospital = _context.Hospitals.ToList();
            var ward = _context.Wards.ToList().ToList();

            var viewModel = new BedFormViewModel
            {
                Hospitals = hospital,
                Wards = ward
            };
            return View("BedForm",viewModel);
        }
        [HttpPost]
        public ActionResult Save(Bed bed)
        {
            if (bed.Id == 0)
            {
                bed.Occupied = "No";
                bed.Patient = null;
                //Count Number of bed in Ward
                var wardId = bed.WardId;

                var wards = _context.Wards.Include(w => w.Beds).ToList();
                var bedsInWard = wards.SingleOrDefault(w => w.Id == wardId);

                if (bedsInWard != null)
                {
                    var bedCount = bedsInWard.Beds.Count;
                    bed.Number = bedCount+1;
                }
               
               

                _context.Beds.Add(bed);
            }
            else
            {
                var bedInDb = _context.Beds.Single(b => b.Id == bed.Id);

                bedInDb.HospitalId = bed.HospitalId;
                bedInDb.WardId = bed.WardId;
            }

            _context.SaveChanges();

            return RedirectToAction("Beds", "Display");
        }

        public ActionResult Edit(int id)
        {
            var bed = _context.Beds.SingleOrDefault(b => b.Id == id);

            if (bed == null)
            {
                return HttpNotFound();
            }

            var viewModel = new BedFormViewModel
            {
                Bed = bed,
                Hospitals = _context.Hospitals.ToList(),
                Wards = _context.Wards.ToList()

            };

            return View("BedForm", viewModel);
        }
    }
}