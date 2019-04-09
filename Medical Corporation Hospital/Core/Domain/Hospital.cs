using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Hospital : IEnumerable
    {
        public Hospital()
        {
            Wards = new HashSet<Ward>();
            Patients = new HashSet<Patient>();
            Doctors = new HashSet<Doctor>();
            Beds = new HashSet<Bed>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }  //Elephant part done
        public virtual City City { get; set; } //Elephant part done
        [Display (Name="City")]
        public int CityId { get; set; }
       public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }

        public virtual ICollection<Bed> Beds { get; set; }
      


        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}