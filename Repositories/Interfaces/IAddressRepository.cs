using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        Task<Address> GetAddressAsync(string id);
        Task<Address> GetAddressAsync(Expression<Func<Address, bool>> expression);
        Task<IEnumerable<Address>> GetAddressesAsync();
    }
}
