using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class HospitalDetailsViewModel
    {
        public List<Hospital> hospital { get; set; }
        public List<Ward> ward { get; set; }
    }
}