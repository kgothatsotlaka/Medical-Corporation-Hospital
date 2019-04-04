using System.Data.Entity.ModelConfiguration;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Persistence.EntityConfigurations
{
    public class HospitalConfiguration: EntityTypeConfiguration<Hospital>
    {
        public HospitalConfiguration()
        {
            Property(h => h.Name)
                .IsRequired()
                .HasMaxLength(250);

            HasRequired(h => h.City)
                .WithMany(c => c.Hospitals)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);

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