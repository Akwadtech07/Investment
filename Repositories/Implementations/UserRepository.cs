using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context)
        {
            _context = context;

        }
        

        public async Task<IEnumerable<User>> GetAll()
        {
            var user = await _context.Users.Include(a => a.Address).Include(a => a.UserRoles).ThenInclude(a => a.Role).ToListAsync();
            return user;
        }

        public async Task<IEnumerable<Role>> GetAllBroker()
        {
            var user = await _context.Roles.Include(x => x.User)
               .Include(x => x.User.Address)
               .Where(x => x.Role.Name == "Brokeer").ToListAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetAllChatContact(int id)
        {
            var user = await _context.Users.Where(x => x.Id != id).ToListAsync();
            return user;
        }

        public async Task<IEnumerable<Role>> GetAllInvestor()
        {
            var user = await _context.Roles.Include(x => x.User)
               .Include(x => x.User.Address)
               .Where(x => x.Role.Name == "Investor").ToListAsync();
            return user;
        }

        public async Task<User> GetUserAsync(string id)
        {
            var user = await _context.Users.Include(x => x.Address).FirstOrDefaultAsync(a => a.Id == id);
            return user;
        }

        public Task<User> GetUserAsync(Expression<Func<User, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUserAsync()
        {
            throw new NotImplementedException();
        }
    }

    public async Task<User> GetUserAsync(Expression<Func<User, bool>> expression)
    {
        var user = await _context.Users.Include(a => a.Roles).ThenInclude(a => a.Role).FirstOrDefaultAsync(expression);
        return user;
    }

   
}

