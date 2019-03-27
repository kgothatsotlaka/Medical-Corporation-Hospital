using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class HospitalDbContext: DbContext
    {
        public HospitalDbContext()
            : base("name=MCH_DB_ConnectingString") { }
       
        public virtual  DbSet<Bed> Beds { get; set; }
        public virtual  DbSet<City> Cities { get; set; }
        public virtual  DbSet<Doctor> Doctors { get; set; }
        public virtual  DbSet<Hospital> Hospitals { get; set; }
        public virtual  DbSet<Patient> Patients { get; set; }
        public virtual  DbSet<Ward> Wards { get; set; }

    }
}