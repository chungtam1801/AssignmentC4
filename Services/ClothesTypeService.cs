using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class ClothesTypeService:IClothesTypeService
    {
        AssignmentDBContext context;
        public ClothesTypeService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateClothesType(ClothesType p)
        {
            try
            {
                context.ClothesTypes.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClothesType(Guid id)
        {
            try
            {
                ClothesType p = context.ClothesTypes.Find(id);
                context.ClothesTypes.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<ClothesType> GetAllClothesType()
        {
            return context.ClothesTypes.ToList();
        }

        public ClothesType GetClothesTypeById(Guid id)
        {
            return context.ClothesTypes.Find(id);
        }
        public bool UpdateClothesType(ClothesType p)
        {
            try
            {
                var ClothesType = context.ClothesTypes.Find(p.ID);
                //ClothesType.Quantity = p.Quantity;
                //ClothesType.Price = p.Price;
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
