using Assignment.Models;

namespace Assignment.IServices
{
    public interface IClothesTypeService
    {
        public List<ClothesType> GetAllClothesType();
        public ClothesType GetClothesTypeById(Guid id);
        public bool CreateClothesType(ClothesType x);
        public bool UpdateClothesType(ClothesType x);
        public bool DeleteClothesType(Guid id);
    }
}
