using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.EntityConfigurations
{
    public class HospitalConfiguration: EntityTypeConfiguration<Hospital>
    {
        public HospitalConfiguration()
        {
            Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}