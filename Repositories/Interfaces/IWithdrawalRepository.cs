using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IWithdrawalRepository
    {
        Task<Withdrawal> GetWithdrawalAsync(string id);
        Task<Withdrawal> GetWithdrawalAsync(Expression<Func<Withdrawal, bool>> expression);
        Task<IEnumerable<Withdrawal>> GetWithdrawalAsync ();
    }
}
