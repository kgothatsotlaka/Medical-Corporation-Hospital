﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class AppointmentsViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
        public IEnumerable<Hospital> Hospitals { get; set; }
        
    }
}