using Assignment.Models;

namespace Assignment.IServices
{
    public interface ISizeService
    {
        public List<Size> GetAllSize();
        public Size GetSizeById(Guid id);
        public bool CreateSize(Size x);
        public bool UpdateSize(Size x);
        public bool DeleteSize(Guid id);
    }
}
