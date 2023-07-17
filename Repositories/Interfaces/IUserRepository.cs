using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IUserRepository
    {
       
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserAsync(string id);
        Task<IEnumerable<User>> GetUserAsync();
        Task<User> GetUserAsync(Expression<Func<User, bool>> expression); 
        Task<IEnumerable<User>> GetAllChatContact(int id);
        Task<IEnumerable<Role>> GetAllBroker();
        Task<IEnumerable<Role>> GetAllInvestor();
    }
}
