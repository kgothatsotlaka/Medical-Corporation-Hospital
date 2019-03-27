using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Occupied { get; set; }
        
        public virtual Ward Ward { get; set; }
        public int WardId { get; set; }
        public Patient Patient { get; set; }


    }
}