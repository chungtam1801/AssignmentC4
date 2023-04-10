using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class ColorService:IColorService
    {
        AssignmentDBContext context;
        public ColorService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateColor(Color p)
        {
            try
            {
                context.Colors.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteColor(Guid id)
        {
            try
            {
                Color p = context.Colors.Find(id);
                context.Colors.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Color> GetAllColor()
        {
            return context.Colors.ToList();
        }

        public Color GetColorById(Guid id)
        {
            return context.Colors.Find(id);
        }
        public bool UpdateColor(Color p)
        {
            try
            {
                var Color = context.Colors.Find(p.ID);
                //Color.Quantity = p.Quantity;
                //Color.Price = p.Price;
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
