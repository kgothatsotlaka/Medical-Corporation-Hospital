using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;

namespace Medical_Corporation_Hospital.Controllers
{
    public class CitiesController : Controller
    {
        // GET: Cities
        protected readonly HospitalDbContext _context;
        public CitiesController()
        {
            _context = new HospitalDbContext();
        }
        public ActionResult New()
        {
          //  var city = _context.Cities
            return View("CityForm");
        }
        [HttpPost]
        public ActionResult Save(City city)
        {
            if (city.Id == 0)
            {
                _context.Cities.Add(city);
            }
            else
            {
                var cityInDb = _context.Cities.Single(c => c.Id == city.Id);

                cityInDb.Name = city.Name;
                cityInDb.Province = city.Province;
                cityInDb.Country = city.Country;
            }

            _context.SaveChanges();
            return RedirectToAction("Cities", "Display");
        }

        public ActionResult Edit(int id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.Id == id);
            if (city == null)
            {
                return HttpNotFound();
            }

            return View("CityForm",city);
        }
    }
}