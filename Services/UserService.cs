using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class UserService : IUserService
    {
        AssignmentDBContext context;
        public UserService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateUser(User p)
        {
            try
            {
                context.Users.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(Guid id)
        {
            try
            {
                User p = context.Users.Find(id);
                context.Users.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<User> GetAllUser()
        {
            return context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return context.Users.Find(id);
        }

        public List<User> GetUserByName(string name)
        {
            return context.Users.Where(p => p.UserName.Contains(name)).ToList();

        }

        public bool UpdateUser(User p)
        {
            try
            {
                var user = context.Users.Find(p.UserID);
                //user.Quantity = p.Quantity;
                //user.Price = p.Price;
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

