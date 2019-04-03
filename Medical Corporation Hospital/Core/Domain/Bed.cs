namespace Medical_Corporation_Hospital.Core.Domain
{
    public class Bed
    {
        public Bed()
        {
          //  Wards = new HashSet<Ward>();
        }
        public int Id { get; set; }
        public int Number { get; set; }
        public string Occupied { get; set; }

        public virtual Ward Ward { get; set; }
        public int wardId { get; set; }


        public  Patient Patient { get; set; }






        // public virtual ICollection<Ward> Wards { get; set; }

        //  public Patient Patient { get; set; }


    }
}