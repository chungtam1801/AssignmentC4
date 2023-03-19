using Assignment.Models;

namespace Assignment.IServices
{
    public interface IUserService
    {
        public List<User> GetAllUser();
        public User GetUserById(Guid id);
        public List<User> GetUserByName(string name);
        public bool CreateUser(User x);
        public bool UpdateUser(User x);
        public bool DeleteUser(Guid id);
    }
}
