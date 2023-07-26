using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class InvestorRepository : BaseRepository<Investor>, IInvestorRepository
    {
        public InvestorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Investor>> GetAllInvestorAsync()
        {
            var investors = await _context.Investors.ToListAsync();
            return investors;
        }

        public async Task<Investor> GetInvestorAsync(string id)
        {
            var investor = await _context.Investors.SingleOrDefaultAsync(a => a.Id == id);
            return investor;
        }

        public async Task<Investor> GetInvestorAsync(Expression<Func<Investor, bool>> expression)
        {
            var investor = await _context.Investors.SingleOrDefaultAsync(expression);
            return investor;
        }

        public async Task<IEnumerable<Investor>> GetInvestorAsync()
        {
            return await _context.Investors.ToListAsync();
        }
    }
}
