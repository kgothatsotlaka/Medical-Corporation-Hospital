﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Profile;

namespace Medical_Corporation_Hospital.Models
{
    public class Hospital
    {
        public Hospital()
        {
            Wards = new List<Ward>();
            Doctors = new List<Doctor>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }




    }
}