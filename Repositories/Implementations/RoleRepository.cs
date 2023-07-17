using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Role> GetRoleAsync(string id)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(a => a.Id == id);
            return role;
        }

        public async Task<Role> GetRoleAsync(Expression<Func<Role, bool>> expression)
        {
            var role = await _context.Roles.SingleOrDefaultAsync(expression);
            return role;
        }

        public async Task<IEnumerable<Role>> GetRoleAsync()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
