using System.Data.Entity.ModelConfiguration;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Persistence.EntityConfigurations
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




            
        }
    }
}