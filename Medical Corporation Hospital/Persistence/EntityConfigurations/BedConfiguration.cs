using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.EntityConfigurations
{
    public class BedConfiguration: EntityTypeConfiguration<Bed>
    {
        public BedConfiguration()
        {
            Property(b => b.Occupied)
                .IsRequired()
                .HasMaxLength(10);


            HasRequired(b => b.Ward)
                .WithMany(w => w.Beds)
                .HasForeignKey(w => w.wardId)
                .WillCascadeOnDelete(false);

            HasOptional(b => b.Patient)
                .WithRequired(p => p.Bed);

        }
    }
}