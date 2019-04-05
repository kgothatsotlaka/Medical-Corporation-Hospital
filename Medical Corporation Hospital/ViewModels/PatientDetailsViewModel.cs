using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class PatientDetailsViewModel
    {
        public  Patient Patient { get; set; }
        public IEnumerable<Patient> Appointments { get; set; }
        public Hospital Hospital { get; set; }

        public Ward Ward { get; set; }
        public Bed Bed { get; set; }
    }
}