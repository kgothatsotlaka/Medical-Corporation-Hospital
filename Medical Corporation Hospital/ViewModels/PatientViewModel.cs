using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class PatientViewModel
    {
        public Patient patient { get; set; }
        public IEnumerable<Hospital> Hospitals { get; set; }
        public IEnumerable<Ward> wards { get; set; }
        public IEnumerable<Bed> Beds { get; set; }
        
    }
}