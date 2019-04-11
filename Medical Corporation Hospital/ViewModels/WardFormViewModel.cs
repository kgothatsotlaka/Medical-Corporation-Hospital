using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class WardFormViewModel
    {
        public IEnumerable<Hospital> Hospitals { get; set; }
        public Ward Ward { get; set; }
    }
}