using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class InvestmentRepository : BaseRepository<Investment>, IInvestmentRepository
    {
        public InvestmentRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Investment> GetInvestmentAsync(string id)
        {
            var investment = await _context.Investments.SingleOrDefaultAsync(a => a.Id == id);
            return investment;
        }

        public async Task<Investment> GetInvestmentAsync(Expression<Func<Investment, bool>> expression)
        {
            var investment = await _context.Investments.SingleOrDefaultAsync(expression);
            return investment;
        }

        public async Task<IEnumerable<Investment>> GetInvestmentAsync()
        {
            return await _context.Investments.ToListAsync();
        }
    }
}
