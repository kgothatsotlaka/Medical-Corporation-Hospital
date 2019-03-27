using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.EntityConfigurations
{
    public class WardConfiguration: EntityTypeConfiguration<Ward>
    {
        public WardConfiguration()
        {
            Property(w => w.Name)
                .IsRequired();

            HasMany(w => w.Beds)
                .WithRequired(b => b.Ward)
                .HasForeignKey(b => b.WardId);
            HasRequired(w => w.Patient)
                .WithRequiredPrincipal(w => w.Ward);
        }
    }
}