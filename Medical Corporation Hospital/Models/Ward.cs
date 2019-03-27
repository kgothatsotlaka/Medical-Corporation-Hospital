using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Corporation_Hospital.Models
{
    public class Ward
    {
        public Ward()
        {
            Beds = new List<Bed>(); // still not sure why we do this
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Hospital Hospital { get; set; }
        public virtual ICollection<Bed> Beds { get; set; } //still not sure why we do this


    }
}