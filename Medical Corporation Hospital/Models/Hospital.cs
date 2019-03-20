using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int NoOfDoctors { get; set; }
        public int NoOfPatients { get; set; }


    }
}