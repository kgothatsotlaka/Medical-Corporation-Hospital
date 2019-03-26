﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Hospital Hospital { get; set; }
        public ICollection<Bed> Beds { get; set; }


    }
}