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


            HasRequired(w => w.Hospital)
                .WithMany(h => h.Wards)
                .HasForeignKey(w => w.HospitalId)
                .WillCascadeOnDelete(false);




            /*  HasMany(w => w.Beds)
                  .WithMany(b => b.Wards)
                  .Map(m =>
                  {
                      m.ToTable("WardBeds");
                      m.MapLeftKey("WardId");
                      m.MapRightKey("BedId");
                  });
              HasRequired(w => w.Patient)
                  .WithRequiredPrincipal(w => w.Ward);
                  */
        }
    }
}