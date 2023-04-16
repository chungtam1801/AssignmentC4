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
                if (GetAllClothesDetail(p.ClothesID).Any())
                {
                    var x = GetClothesDetailByColorAndSize(p.ColorID, p.SizeID, p.ClothesID);
                    if (x != null)
                    {
                        x.Quantity += p.Quantity;
                        context.SaveChanges();
                        return true;
                    }
                    p.Status = 2; 
                } 
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
                var clothesDetail = context.ClothesDetails.Find(p.ID);
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
            obj.Color = _colorService.GetColorById(clothesDetail.ColorID).Value;
            obj.Size = _sizeService.GetSizeById(clothesDetail.SizeID).Value;
            obj.Price = clothes.Price;
            obj.Quantity = clothesDetail.Quantity;
            obj.Description = clothes.Description;
            obj.ImageLocation = clothes.ImamgeLocation;
            return obj;
        }
        public ClothesDetail? GetClothesDetailByColorAndSize(Guid idColor,Guid idSize,Guid idClothes)
        {
            return context.ClothesDetails.FirstOrDefault(x => x.ColorID == idColor && x.SizeID == idSize && x.ClothesID == idClothes);
        }
        public bool SetDefaultClothesDetail(Guid id)
        {
            try
            {
                var obj1 = context.ClothesDetails.FirstOrDefault(x => x.Status == 1);
                obj1.Status = 2;
                var obj2 = context.ClothesDetails.FirstOrDefault(x => x.ID == id);
                obj2.Status = 1;
                context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
