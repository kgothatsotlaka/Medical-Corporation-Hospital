using System.Collections.Generic;

namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Hospital
    {
        public Hospital()
        {
            Wards = new HashSet<Ward>();
            Patients = new HashSet<Patient>();
            Doctors = new HashSet<Doctor>();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }  //Elephant part done
        public virtual City City { get; set; } //Elephant part done
        public int CityId { get; set; }
       public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }




    }
}