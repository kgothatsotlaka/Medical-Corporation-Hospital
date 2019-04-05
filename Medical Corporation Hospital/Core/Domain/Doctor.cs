using System.Collections.Generic;

namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Doctor
    {
        public Doctor()
        {
            Hospitals = new HashSet<Hospital>();
            Patients =new HashSet<Patient>();
        }
        public int Id { get; set; }
        public string Initials { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
       // public Hospital HospitalId { get; set; }
      public virtual ICollection<Patient> Patients { get; set; }


    }
}