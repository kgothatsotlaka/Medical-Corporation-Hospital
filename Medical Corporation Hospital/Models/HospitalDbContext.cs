using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.EntityConfigurations;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new HospitalConfiguration());
            modelBuilder.Configurations.Add(new BedConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new DoctorConfiguration());
            modelBuilder.Configurations.Add(new PatientConfiguration());
            modelBuilder.Configurations.Add(new WardConfiguration());
        }
    }
}