using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class CartDetailService : ICartDetailService
    {
        AssignmentDBContext context;
        public CartDetailService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateCartDetail(CartDetail p)
        {
            try
            {
                context.CartDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteCartDetail(Guid id)
        {
            try
            {
                CartDetail p = context.CartDetails.Find(id);
                context.CartDetails.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<CartDetail> GetAllCartDetail()
        {
            return context.CartDetails.ToList();
        }

        public CartDetail GetCartDetailById(Guid id)
        {
            return context.CartDetails.Find(id);
        }
        public bool UpdateCartDetail(CartDetail p)
        {
            try
            {
                var cartDetail = context.CartDetails.Find(p.ID);
                //cartDetail.Quantity = p.Quantity;
                //cartDetail.Price = p.Price;
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

