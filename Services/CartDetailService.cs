using Assignment.IServices;
using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.Services
{
    public class CartDetailService : ICartDetailService
    {
        AssignmentDBContext context;
        IUserService _userService;
        public CartDetailService()
        {
            context = new AssignmentDBContext();
            _userService = new UserService();
        }
        public bool CreateCartDetail(CartDetail p)
        {
            try
            { 
                if(context.Carts.FirstOrDefault(y=>y.UserID==p.UserID) == null)
                {
                    context.Carts.Add(new Cart() { UserID = p.UserID ,Description=""});
                }
                var tempCartDetail = context.CartDetails.FirstOrDefault(x=>x.ClothesDetailID==p.ClothesDetailID && x.UserID == p.UserID);
                if (tempCartDetail != null)
                {
                    tempCartDetail.Quantity++;
                }
                else
                {
                    p.Quantity = 1;
                    context.CartDetails.Add(p);
                }
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
        public CartVM GetAllCartVM(Guid id)
        {
            var cartVM = new CartVM();
            var lst = (from a in context.CartDetails.Where(x => x.UserID == id)
                       join b in context.ClothesDetails on a.ClothesDetailID equals b.ID
                       join c in context.Clotheses on b.ClothesID equals c.ID
                       join d in context.ClothesTypes on c.ClothesTypeID equals d.ID
                       join e in context.Colors on b.ColorID equals e.ID
                       join f in context.Sizes on b.SizeID equals f.ID
                       select new CartDetailVM()
                       {
                           ID = b.ID,
                           Name = c.Name,
                           Type = d.Name,
                           Price = c.Price,
                           Color = e.Value,
                           Size = f.Value,
                           SumPrice = c.Price * a.Quantity,
                           Quantity = a.Quantity
                       }).ToList();
            cartVM.ListClothes = lst;
            cartVM.SumPrice = lst.Sum(x => x.SumPrice);
            return cartVM;
        }
    }
}

