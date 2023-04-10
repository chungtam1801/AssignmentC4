namespace Assignment.ViewModels
{
    public class CartDetailVM
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public int Price { get; set; }
        public int SumPrice { get; set; }
        public int Quantity { get; set; }
    }
}
