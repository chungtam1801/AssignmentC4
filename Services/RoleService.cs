using Assignment.IServices;
using Assignment.Models;

namespace Assignment.Services
{
    public class RoleService : IRoleService
    {
        AssignmentDBContext context;
        public RoleService()
        {
            context = new AssignmentDBContext();
        }
        public bool CreateRole(Role p)
        {
            try
            {
                context.Roles.Add(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteRole(Guid id)
        {
            try
            {
                Role p = context.Roles.Find(id);
                context.Roles.Remove(p);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public List<Role> GetAllRole()
        {
            return context.Roles.ToList();
        }

        public Role GetRoleById(Guid id)
        {
            return context.Roles.Find(id);
        }
        public bool UpdateRole(Role p)
        {
            try
            {
                var role = context.Roles.Find(p.ID);
                //role.Quantity = p.Quantity;
                //role.Price = p.Price;
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

