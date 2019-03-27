﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
       
        public ICollection<Hospital> Hospitals { get; set; }


    }
}