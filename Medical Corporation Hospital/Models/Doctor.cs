using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public ICollection<Hospital> Hospitals { get; set; }
        public ICollection<Patient> Patients { get; set; }


    }
}