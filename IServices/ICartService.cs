using Assignment.Models;

namespace Assignment.IServices
{
    public interface ICartService
    {
        public List<Cart> GetAllCart();
        public Cart GetCartById(Guid id);
        public bool CreateCart(Cart x);
        public bool UpdateCart(Cart x);
        public bool DeleteCart(Guid id);
    }
}
