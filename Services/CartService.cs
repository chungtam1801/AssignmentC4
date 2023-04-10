using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class CartService : ICartService
    {
        AssignmentDBContext context;
        public CartService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateCart(Cart p)
        {
            try
            {
                context.Carts.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCart(Guid id)
        {
            try
            {
                foreach(var x in context.CartDetails.Where(x=>x.UserID==id))
                {
                    context.CartDetails.Remove(x);
                }
                Cart p = context.Carts.Find(id);
                context.Carts.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Cart> GetAllCart()
        {
            return context.Carts.ToList();
        }

        public Cart GetCartById(Guid id)
        {
            return context.Carts.Find(id);
        }
        public bool UpdateCart(Cart p)
        {
            try
            {
                var cart = context.Carts.Find(p.UserID);
                //cart.Quantity = p.Quantity;
                //cart.Price = p.Price;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

