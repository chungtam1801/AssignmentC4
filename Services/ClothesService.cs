using Assignment.IServices;
using Assignment.Models;
using Assignment.ViewModels;

namespace Assignment.Services
{
    public class ClothesService : IClothesService
    {
        AssignmentDBContext context;
        private IClothesDetailService _clothesDetailService;
        public ClothesService()
        {
            context = new AssignmentDBContext();
            _clothesDetailService = new ClothesDetailService();
        }
        public bool CreateClothes(Clothes p)
        {
            try
            {
                p.ClothesTypeID = new Guid("06219696-300B-4596-B941-9B8276FB1F9A");
                context.Clotheses.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteClothes(Guid id)
        {
            try
            {
                Clothes p = context.Clotheses.Find(id);
                foreach(var x in _clothesDetailService.GetAllClothesDetail(id))
                {
                    context.ClothesDetails.Remove(x);
                }
                context.Clotheses.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Clothes> GetAllClothes()
        {
            return context.Clotheses.ToList();
        }

        public Clothes GetClothesById(Guid id)
        {
            return context.Clotheses.Find(id);
        }

        public List<Clothes> GetClothesByName(string name)
        {
            return context.Clotheses.Where(p => p.Name.Contains(name)).ToList();
        }

        public bool UpdateClothes(Clothes p)
        {
            try
            {
                var clothes = context.Clotheses.Find(p.ID);
                clothes.ImamgeLocation=p.ImamgeLocation; 
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<ClothesVM> GetAllClothesView()
        {
            var lst = new List<ClothesVM>();
            foreach(var x in GetAllClothes())
            {
                var y = _clothesDetailService.GetAllClothesDetail(x.ID).FirstOrDefault(x => x.Status == 1);
                if (y!=null)
                {
                    lst.Add(new ClothesVM() { ID = y.ID, Name = x.Name, Price = x.Price, Quantity = y.Quantity ,ImageLocation=x.ImamgeLocation});
                }
            }
            return lst;
        }
        public List<Color> GetColorClothes(Guid id)
        {
            var list = (from a in context.ClothesDetails.Where(x => x.ClothesID == id)
                        join b in context.Colors on a.ColorID equals b.ID
                        select b).Distinct().ToList();
            return list;
        }
        public List<Size> GetSizeClothes(Guid id)
        {
            var list = (from a in context.ClothesDetails.Where(x => x.ClothesID == id)
                        join b in context.Sizes on a.SizeID equals b.ID
                        select b).Distinct().ToList();
            return list;
        }
    }
}

