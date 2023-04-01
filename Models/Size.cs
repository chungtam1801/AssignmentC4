namespace Assignment.Models
{
    public class Size
    {
        public Guid ID { get; set; }
        public string Value { get; set; }
        public virtual IEnumerable<ClothesDetail> ClothesDetails { get; set; }
    }
}
