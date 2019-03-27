using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using Medical_Corporation_Hospital.Models;

namespace Medical_Corporation_Hospital.EntityConfigurations
{
    public class CityConfiguration: EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(500);
            Property(c => c.Country)
                .IsRequired()
                .HasMaxLength(250);
            Property(c => c.Province)
                .IsRequired()
                .HasMaxLength(250);

            HasMany(c => c.Hospitals)
                .WithRequired(h => h.City)
                .HasForeignKey(c => c.CityId);




        }
    }
}