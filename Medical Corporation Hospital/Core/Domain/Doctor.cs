using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        public string Initials { get; set; }        
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Telephone { get; set; }
        public virtual ICollection<Hospital> Hospitals { get; set; }
       // public Hospital HospitalId { get; set; }
      public virtual ICollection<Patient> Patients { get; set; }


    }
}