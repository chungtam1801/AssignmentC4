using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.IServices
{
    public interface IClothesDetailService
    {
        public List<ClothesDetail> GetAllClothesDetail(Guid id);
        public ClothesDetail GetClothesDetailById(Guid id);
        public bool CreateClothesDetail(ClothesDetail x);
        public bool UpdateClothesDetail(ClothesDetail x);
        public bool DeleteClothesDetail(Guid id);
        public ClothesDetailVM GetClothesDetailVM(ClothesDetail clothesDetail, Clothes clothes);
        public ClothesDetail? GetClothesDetailByColorAndSize(Guid? idColor, Guid? idSize, Guid idClothes);

    }
}
