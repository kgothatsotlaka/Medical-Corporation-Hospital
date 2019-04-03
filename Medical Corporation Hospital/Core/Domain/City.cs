using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class City
    {
        public City()
        {
            Hospitals =  new HashSet<Hospital>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
       
        public virtual ICollection<Hospital> Hospitals { get; set; }


    }
}