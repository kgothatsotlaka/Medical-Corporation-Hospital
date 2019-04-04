using System.Data.Entity.ModelConfiguration;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Persistence.EntityConfigurations
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
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);




        }
    }
}