using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IBrokerRepository 
    {
        Task<Broker> GetBrokerAsync(string id);
        Task<Broker> GetBrokerAsync(Expression<Func<Broker, bool>> expression);
        Task<IEnumerable<Broker>> GetBrokerAsync();
    }
}
