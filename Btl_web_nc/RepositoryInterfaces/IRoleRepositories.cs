using Btl_web_nc.Models;

namespace Btl_web_nc.RepositoryInterfaces
{
    public interface IRoleRepositories
    {
        public Task<Role> GetRoleByIdAsync(long roleId);
    }
}
