﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Medical_Corporation_Hospital.Core.Domain;
using Medical_Corporation_Hospital.Persistence;
using Medical_Corporation_Hospital.ViewModels;

namespace Medical_Corporation_Hospital.Controllers
{
    public class HospitalController : Controller
    {
        // GET: Hospital
        private readonly HospitalDbContext _context;
        public HospitalController()
        {
            _context =new HospitalDbContext();
        }
        public ActionResult New()
        {
           
            var city = _context.Cities.ToList();

            var viewModel = new HospitalFormViewModel
            {
                Hospital = new Hospital(),
                Cities = city
            };

            return View("HospitalForm", viewModel);
        }
        [HttpPost]
        public ActionResult Save(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new HospitalFormViewModel
                {
                    Hospital = hospital,
                    Cities = _context.Cities.ToList()
                };
                return View("HospitalForm", viewModel);
            }
           
            if (hospital.Id == 0)
            {
                _context.Hospitals.Add(hospital);

            }
            else
            {
                var hospitalInDb = _context.Hospitals.Single(h => h.Id == hospital.Id);

                hospitalInDb.Name = hospital.Name;
                hospitalInDb.CityId = hospital.CityId;

            }

            _context.SaveChanges();


            return RedirectToAction("Hospitals", "Display");
        }

        public ActionResult Edit(int id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);

            if (hospital == null)
            {
                return HttpNotFound();
            }

            var viewModel = new HospitalFormViewModel
            {
                Hospital = hospital,
                Cities = _context.Cities.ToList()
            };
            return View("HospitalForm", viewModel);
        }

        public ActionResult Remove(int id)
        {
            var hospital = _context.Hospitals.SingleOrDefault(h => h.Id == id);

            if (hospital != null)
            {
                hospital.Doctors = null;
                hospital.Wards = null;
                hospital.City = null;
                hospital.Patients = null;
                hospital.Beds = null;
             

                _context.Hospitals.Remove(hospital);
            
            }
            _context.SaveChanges();
            return RedirectToAction("Hospitals", "Display");
        }
    }
}