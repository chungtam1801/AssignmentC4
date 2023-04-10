using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.IServices
{
    public interface ICartDetailService
    {
        public List<CartDetail> GetAllCartDetail();
        public CartDetail GetCartDetailById(Guid id);
        public bool CreateCartDetail(CartDetail x);
        public bool UpdateCartDetail(CartDetail x);
        public bool DeleteCartDetail(Guid id);
        public CartVM GetAllCartVM(Guid id);
    }
}
