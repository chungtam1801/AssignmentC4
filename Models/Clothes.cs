namespace Assignment.Models
{
    public class Clothes
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public Guid ClothesTypeID { get; set; }
        public virtual ClothesType ClothesType { get; set; }
        public virtual IEnumerable<ClothesDetail> ClothesDetails { get; set; }

    }
}
