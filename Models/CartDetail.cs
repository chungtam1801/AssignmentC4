namespace Assignment.Models
{
    public class CartDetail
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ClothesDetailID { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual ClothesDetail ClothesDetail { get; set; }
    }
}
