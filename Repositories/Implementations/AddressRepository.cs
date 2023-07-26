using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Dtos;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(ApplicationContext context) 
        { 
            _context = context; 
        }
        public async Task<Address> GetAddressAsync(string id)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(a => a.Id == id);
            return address;
        }

        public async Task<Address> GetAddressAsync(Expression<Func<Address, bool>> expression)
        {
            var address = await _context.Addresses.SingleOrDefaultAsync(expression);
            return address;
        }

        public async Task<IEnumerable<Address>> GetAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }
    }
}
