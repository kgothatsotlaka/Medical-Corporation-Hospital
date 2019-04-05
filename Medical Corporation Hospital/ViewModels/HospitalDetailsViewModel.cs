using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.ViewModels
{
    public class HospitalDetailsViewModel
    {
        public Hospital Hospital { get; set; }
        public IEnumerable<Ward> Wards { get; set; }
        public List<Bed> Beds { get; set; }
        public ICollection<Hospital> WorksAt { get; set; }
        public City City { get; set; }
       

    }
}