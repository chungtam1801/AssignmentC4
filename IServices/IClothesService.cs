using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.IServices
{
    public interface IClothesService
    {
        public List<Clothes> GetAllClothes();
        public Clothes GetClothesById(Guid id);
        public List<Clothes> GetClothesByName(string name);
        public bool CreateClothes(Clothes p);
        public bool UpdateClothes(Clothes p);
        public bool DeleteClothes(Guid id);
        public List<ClothesVM> GetAllClothesView();
        public List<Size> GetSizeClothes(Guid id);
        public List<Color> GetColorClothes(Guid id);

    }
}
