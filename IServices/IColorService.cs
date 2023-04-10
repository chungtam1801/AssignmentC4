using Assignment.Models;

namespace Assignment.IServices
{
    public interface IColorService
    {
        public List<Color> GetAllColor();
        public Color GetColorById(Guid id);
        public bool CreateColor(Color x);
        public bool UpdateColor(Color x);
        public bool DeleteColor(Guid id);
    }
}
