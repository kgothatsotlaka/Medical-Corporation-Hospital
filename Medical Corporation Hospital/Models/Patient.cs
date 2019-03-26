using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? AdmissionTime { get; set; }
        public string Address { get; set; }
        public  string Telephone { get; set; }
        public Hospital Hospital { get; set; }
        public Ward Ward { get; set; }
        public Bed Bed { get; set; }

    }
}