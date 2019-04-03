using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Patient
    {
        public Patient()
        {
           Doctors =  new HashSet<Doctor>(); //still not sure why we do this

        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? AdmissionTime { get; set; }
        public string Address { get; set; }
        public  string Telephone { get; set; }
        public virtual Hospital Hospital { get; set; }
        public int HospitalId { get; set; }
        public virtual  Ward Ward { get; set; }
        public int WardId { get; set; }

        public  Bed Bed { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }


        //   
        //   public  Bed Bed { get; set; }
        //     public int BedId { get; set; }
        //     // still not sure why we include virtual

    }
}