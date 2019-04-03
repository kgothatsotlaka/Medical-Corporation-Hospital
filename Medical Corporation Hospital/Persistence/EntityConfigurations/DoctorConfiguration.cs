using System.Data.Entity.ModelConfiguration;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Persistence.EntityConfigurations
{
    public class DoctorConfiguration : EntityTypeConfiguration<Doctor>
    {
        public DoctorConfiguration()
        {
            Property(d => d.Initials)
                .IsRequired()
                .HasMaxLength(10);
            Property(d => d.LastName)
                .IsRequired()
                .HasMaxLength(250);
            Property(d => d.Address)
                .IsRequired()
                .HasMaxLength(1000);
            Property(d => d.Telephone)
                .IsRequired()
                .HasMaxLength(10);

            
        }
    }
}