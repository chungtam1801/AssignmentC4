namespace Assignment.Models
{
    public class Clothes
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public string Supplier { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<CartDetail> CartDetails { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }
    }
}
