namespace Assignment.Models
{
    public class ClothesType
    {
		public Guid ID { get; set; }
		public string Name { get; set; }
        public Guid? DadTypeID { get; set; }
        public virtual ClothesType DadType { get; set; }
        public virtual IEnumerable<Clothes> Clotheses { get; set; }
    }
}
