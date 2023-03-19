using Assignment.Models;

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
    }
}
