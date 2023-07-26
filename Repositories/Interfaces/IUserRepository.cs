using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
       
        Task<IEnumerable<User>> GetAll();
        Task<User> GetUserAsync(string id);
        Task<IEnumerable<User>> GetUserAsync();
        Task<User> GetUserAsync(Expression<Func<User, bool>> expression); 
        Task<IEnumerable<User>> GetAllChatContact(string id);
        Task<IEnumerable<User>> GetAllBroker();
        Task<IEnumerable<User>> GetAllInvestor();
    }
}
