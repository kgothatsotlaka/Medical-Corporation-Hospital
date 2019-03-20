using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Ward
    {
        public int WardId { get; set; }
        public string WardName { get; set; }
        public string HospitalName { get; set; }
        public int NoOfBeds { get; set; }
    }
}