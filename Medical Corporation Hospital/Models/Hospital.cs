using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Medical_Corporation_Hospital.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public ICollection<Ward> Wards { get; set; }
        public ICollection<Doctor> Doctors { get; set; }




    }
}