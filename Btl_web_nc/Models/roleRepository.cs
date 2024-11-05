using Btl_web_nc.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Btl_web_nc.Models
{
    public class RoleRepository:IRoleRepositories
    {
        private readonly AppDbContext _dbContext;
        public RoleRepository(AppDbContext db)
        {
            _dbContext = db;
        }

        public async Task<Role> GetRoleByIdAsync(long roleId)
        {
            return await _dbContext.Roles.SingleOrDefaultAsync(role => role.roleId == roleId);
        }
    }
}
