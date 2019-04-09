using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class HospitalFormViewModel
    {
        public IEnumerable<City> Cities { get; set; }
        public Hospital Hospital { get; set; }
    }
}