using Assignment.Models;

namespace Assignment.IServices
{
    public interface IUserService
    {
        public List<User> GetAllUser();
        public User GetUserById(Guid id);
        public User? GetUserByName(string name);
        public bool CreateUser(User x);
        public bool UpdateUser(User x);
        public bool DeleteUser(Guid id);
        public User? Login(string name, string password);

    }
}
