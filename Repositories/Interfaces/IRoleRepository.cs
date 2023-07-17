using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleAsync(string id);
        Task<Role> GetRoleAsync(Expression<Func<Role, bool>> expression);
        Task<IEnumerable<Role>> GetRoleAsync();
    }
}
