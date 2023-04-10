namespace Assignment.Models
{
    public class ClothesDetail
    {
        public Guid ID { get; set; }
        public int Quantity { get; set; }
        public int Status { get; set; }
        public Guid ClothesID { get; set; }
        public Guid? ColorID { get; set; }
        public Guid? SizeID { get; set; }
        public virtual Clothes Clothes { get; set; }
        public virtual Color Color { get; set; }
        public virtual Size Size { get; set; }
        public virtual IEnumerable<CartDetail> CartDetails { get; set; }
        public virtual IEnumerable<BillDetail> BillDetails { get; set; }

    }
}
