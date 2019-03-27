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

            HasMany(h => h.Patients)
                .WithRequired(p => p.Hospital)
                .HasForeignKey(p => p.HospitalId);
            HasMany(h => h.Wards)
                .WithRequired(w => w.Hospital)
                .HasForeignKey(w => w.HospitalId);
            HasMany(h => h.Doctors)
                .WithMany(d => d.Hospitals)
                .Map(m =>
                {
                    m.ToTable("Works");
                    m.MapLeftKey("HospitalId");
                    m.MapRightKey("DoctorsId");
                });


        }
    }
}