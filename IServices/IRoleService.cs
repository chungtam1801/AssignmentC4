using Assignment.Models;

namespace Assignment.IServices
{
    public interface IRoleService
    {
        public List<Role> GetAllRole();
        public Role GetRoleById(Guid id);
        public bool CreateRole(Role x);
        public bool UpdateRole(Role x);
        public bool DeleteRole(Guid id);
    }
}
