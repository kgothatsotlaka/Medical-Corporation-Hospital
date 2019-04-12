using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class BedFormViewModel
    {
        public IEnumerable<Hospital> Hospitals { get; set; }
        public IEnumerable<Ward> Wards { get; set; }
        public Bed Bed { get; set; }
      //  public Patient Patient{get; set; }
    }
}