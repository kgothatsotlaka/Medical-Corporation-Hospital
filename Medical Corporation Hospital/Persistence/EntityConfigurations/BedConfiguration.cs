using System.Data.Entity.ModelConfiguration;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Persistence.EntityConfigurations
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
                .HasForeignKey(w => w.WardId)
                .WillCascadeOnDelete(false);

            HasRequired(b=>b.Hospital)
                .WithMany(h=>h.Beds)
                .HasForeignKey(h=>h.HospitalId)
                .WillCascadeOnDelete(false);

            HasOptional(b => b.Patient)
                .WithRequired(p => p.Bed);

        }
    }
}