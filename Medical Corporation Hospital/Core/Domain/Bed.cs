    using System.ComponentModel.DataAnnotations;

    namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Bed
    {
        public Bed()
        {

        }
        public int Id { get; set; }
        public int Number { get; set; }
        public string Occupied { get; set; }

        public virtual Ward Ward { get; set; }
        [Required]
        public int WardId { get; set; }

        public virtual Hospital Hospital { get; set; }
        [Required]
        public int HospitalId { get; set; }

        public  Patient Patient { get; set; }





    }
}