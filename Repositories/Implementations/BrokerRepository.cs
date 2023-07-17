using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class BrokerRepository : BaseRepository<InvestmentType>, IBrokerRepository
    {
        public BrokerRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Broker> GetBrokerAsync(string id)
        {
            var broker = await _context.Brokers.SingleOrDefaultAsync(a => a.Id == id);
            return broker;
        }

        public async Task<Broker> GetBrokerAsync(Expression<Func<Broker, bool>> expression)
        {
            var broker = await _context.Brokers.SingleOrDefaultAsync(expression);
            return broker;
        }

        public async Task<IEnumerable<Broker>> GetBrokerAsync()
        {
            return await _context.Brokers.ToListAsync();
        }
    }
}
