using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.EntityConfigurations
{
    public class PatientConfiguration: EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
            Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(250);
            Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(1000);
            Property(p => p.Telephone)
                .IsRequired()
                .HasMaxLength(10);
            Property(p => p.AdmissionTime)
                .IsRequired();
          



        }
    }
}