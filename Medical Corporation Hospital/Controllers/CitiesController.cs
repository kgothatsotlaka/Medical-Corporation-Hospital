﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
        private readonly HospitalDbContext _context;
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
            if (!ModelState.IsValid)
            {
                return View("CityForm");
            }
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

        public ActionResult Remove(int id)
        {
            var city = _context.Cities.SingleOrDefault(c => c.Id == id);
            if (city != null)
            {
                city.Hospitals = null;
                _context.Cities.Remove(city);
                _context.SaveChanges();
            }

            return RedirectToAction("Cities", "Display");
        }
    }
}