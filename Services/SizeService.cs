using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class SizeService:ISizeService
    {
        AssignmentDBContext context;
        public SizeService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateSize(Size p)
        {
            try
            {
                context.Sizes.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteSize(Guid id)
        {
            try
            {
                Size p = context.Sizes.Find(id);
                context.Sizes.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Size> GetAllSize()
        {
            return context.Sizes.ToList();
        }

        public Size GetSizeById(Guid id)
        {
            return context.Sizes.Find(id);
        }
        public bool UpdateSize(Size p)
        {
            try
            {
                var Size = context.Sizes.Find(p.ID);
                //Size.Quantity = p.Quantity;
                //Size.Price = p.Price;
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
