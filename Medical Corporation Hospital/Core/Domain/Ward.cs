using System.Collections.Generic;

namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Ward
    {
        public Ward()
        {
            Patients = new HashSet<Patient>();
             Beds = new HashSet<Bed>(); // still not sure why we do this
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Hospital Hospital { get; set; }
        public int HospitalId { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Bed> Beds { get; set; } //still not sure why we do this

        


    }
}