using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

namespace Medical_Corporation_Hospital.Core.Domain
{
    public class City
    {
        public City()
        {
            Hospitals =  new HashSet<Hospital>();
        }
       
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Province { get; set; }
        [Required]
        public string Country { get; set; }
       
        public virtual ICollection<Hospital> Hospitals { get; set; }


    }
}