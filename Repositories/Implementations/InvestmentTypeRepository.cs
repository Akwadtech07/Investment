using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Dtos;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class InvestmentTypeRepository : BaseRepository<InvestmentType>, IInvestmentTypeRepository
    {
        public InvestmentTypeRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<InvestmentType> GetInvestmentTypeAsync(string id)
        {
            var investmentType = await _context.InvestmentsTypes.SingleOrDefaultAsync(a => a.Id == id);
            return investmentType;
        }

        public async Task<InvestmentType> GetInvestmentTypeAsync(Expression<Func<InvestmentType, bool>> expression)
        {
            var investmentType = await _context.InvestmentsTypes.SingleOrDefaultAsync(expression);
            return investmentType;
        }

        public async Task<IEnumerable<InvestmentType>> GetInvestmentTypeAsync()
        {
            return await _context.InvestmentsTypes.ToListAsync();
        }
    }
}
