namespace Assignment.Models
{
    public class CartDetail
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public Guid ClothesID { get; set; }
        public int Quantity { get; set; }
        public virtual Cart Cart { get; set; }
        public virtual Clothes Clothes { get; set; }
    }
}
