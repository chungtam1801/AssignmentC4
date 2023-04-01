namespace Assignment.Models
{
    public class BillDetail
    {
        public Guid ID { get; set; }
        public Guid BillID { get; set; }
        public Guid ClothesDetailID { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ClothesDetail ClothesDetail { get; set; }
    }
}
