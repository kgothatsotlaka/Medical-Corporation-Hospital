﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class WardsController : Controller
    {
        // GET: Wards
        private readonly HospitalDbContext _context;
        public WardsController()
        {
            _context = new HospitalDbContext();
        }
        public ActionResult New()
        {
            var hospitals = _context.Hospitals.ToList();

            var viewModel = new WardFormViewModel
            {
                Hospitals = hospitals
            };
            return View("WardForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Ward ward)
        {
            if (ward.Id == 0)
            {
                _context.Wards.Add(ward);

            }
            else
            {
                var wardInDb = _context.Wards.Single(w => w.Id == ward.Id);
                wardInDb.Name = ward.Name;
                wardInDb.HospitalId = ward.HospitalId;
            }

            _context.SaveChanges();

            return RedirectToAction("Wards", "Display");
        }

        public ActionResult Edit(int id)
        {
            var ward = _context.Wards.SingleOrDefault(w => w.Id == id);
            if (ward == null)
            {
                return HttpNotFound();
            }

            var viewModel = new WardFormViewModel
            {
                Ward = ward,
                Hospitals = _context.Hospitals.ToList()
            };

            return View("WardForm", viewModel);
        }
    }
}