using Assignment.IServices;
using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.Services
{
    public class ClothesDetailService:IClothesDetailService
    {
        AssignmentDBContext context;
        private IColorService _colorService;
        private ISizeService _sizeService;
        private IClothesTypeService _clothesTypeService;
        public ClothesDetailService()
        {
            context = new AssignmentDBContext();
            _clothesTypeService = new ClothesTypeService();
            _colorService = new ColorService();
            _sizeService = new SizeService();
        }
        public bool CreateClothesDetail(ClothesDetail p)
        {
            try
            {
                if (GetAllClothesDetail(p.ClothesID).Any()) p.Status = 2;
                else p.Status = 1;
                context.ClothesDetails.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClothesDetail(Guid id)
        {
            try
            {
                ClothesDetail p = context.ClothesDetails.Find(id);
                context.ClothesDetails.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<ClothesDetail> GetAllClothesDetail(Guid id)
        {
            return context.ClothesDetails.Where(x=>x.ClothesID==id).ToList();
        }

        public ClothesDetail GetClothesDetailById(Guid id)
        {
            return context.ClothesDetails.Find(id);
        }
        public bool UpdateClothesDetail(ClothesDetail p)
        {
            try
            {
                var ClothesDetail = context.ClothesDetails.Find(p.ID);
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
        public ClothesDetailVM GetClothesDetailVM(ClothesDetail clothesDetail,Clothes clothes)
        {
            var obj = new ClothesDetailVM();
            obj.ID = clothesDetail.ID;
            obj.Name = clothes.Name;
            obj.Type = _clothesTypeService.GetClothesTypeById(clothes.ClothesTypeID).Name;
            obj.Color = _colorService.GetColorById(clothesDetail.ColorID ?? new Guid()).Value;
            obj.Size = _sizeService.GetSizeById(clothesDetail.SizeID ?? new Guid()).Value;
            obj.Price = clothes.Price;
            obj.Quantity = clothesDetail.Quantity;
            obj.Description = clothes.Description;
            return obj;
        }
        public ClothesDetail? GetClothesDetailByColorAndSize(Guid? idColor,Guid? idSize,Guid idClothes)
        {
            return context.ClothesDetails.FirstOrDefault(x => x.ColorID == idColor && x.SizeID == idSize && x.ClothesID == idClothes);
        }
    }
}
