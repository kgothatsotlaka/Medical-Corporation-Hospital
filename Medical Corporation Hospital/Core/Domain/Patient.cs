using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Patient
    {
        public Patient()
        {
           Doctors =  new HashSet<Doctor>(); //still not sure why we do this

        }
        public int Id { get; set; }
        [Display (Name="Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Admission Date")]
        public DateTime? AdmissionTime { get; set; }
        public string Address { get; set; }
        public  string Telephone { get; set; }
        public virtual Hospital Hospital { get; set; }
        [Display(Name = "Hospital")]
        public int HospitalId { get; set; }
        public virtual  Ward Ward { get; set; }
        [Display(Name = "Ward")]
        public int WardId { get; set; }

        [Display(Name = "Bed")]

        public  Bed Bed { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }


        //   
        //   public  Bed Bed { get; set; }
        //     public int BedId { get; set; }
        //     // still not sure why we include virtual

    }
}