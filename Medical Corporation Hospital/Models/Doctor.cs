using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Hospitals = new List<Hospital>();
            Patients =new List<Patient>();
        }
        public int Id { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }


    }
}