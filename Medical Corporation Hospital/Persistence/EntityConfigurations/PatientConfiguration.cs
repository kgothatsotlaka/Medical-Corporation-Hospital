using System.Data.Entity.ModelConfiguration;
using Medical_Corporation_Hospital.Core.Domain;

namespace Medical_Corporation_Hospital.Persistence.EntityConfigurations
{
    public class PatientConfiguration: EntityTypeConfiguration<Patient>
    {
        public PatientConfiguration()
        {
            Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(250);
            Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(1000);
            Property(p => p.Telephone)
                .IsRequired()
                .HasMaxLength(10);
            Property(p => p.AdmissionTime)
                .IsRequired();

            HasRequired(p => p.Hospital)
                .WithMany(h => h.Patients)
                .HasForeignKey(h => h.HospitalId)
                .WillCascadeOnDelete(false);
            HasRequired(p => p.Ward)
                .WithMany(w => w.Patients)
                .HasForeignKey(w => w.WardId)
                .WillCascadeOnDelete(false);

            HasMany(p => p.Doctors)
                .WithMany(d => d.Patients)
                .Map(m =>
                {
                    m.ToTable("Appointments");
                    m.MapLeftKey("PatientId");
                    m.MapRightKey("DoctorsId");
                });





        }
    }
}