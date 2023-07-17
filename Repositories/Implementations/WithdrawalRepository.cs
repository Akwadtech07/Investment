using Microsoft.EntityFrameworkCore;
using New_folder.Data;
using New_folder.Models.Entities;
using New_folder.Repositories.Interfaces;
using System.Linq.Expressions;

namespace New_folder.Repositories.Implementations
{
    public class WithdrawalRepository : BaseRepository<Withdrawal>, IWithdrawalRepository
    {
        public WithdrawalRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Withdrawal> GetWithdrawalAsync(string id)
        {
            var withdrawal = await _context.Withdrawals.SingleOrDefaultAsync(a => a.Id == id);
            return withdrawal;
        }

        public async Task<Withdrawal> GetWithdrawalAsync(Expression<Func<Withdrawal, bool>> expression)
        {
            var withdrawal = await _context.Withdrawals.SingleOrDefaultAsync(expression);
            return withdrawal;
        }

        public async Task<IEnumerable<Withdrawal>> GetWithdrawalAsync()
        {
            return await _context.Withdrawals.ToListAsync();
        }
    }
}
