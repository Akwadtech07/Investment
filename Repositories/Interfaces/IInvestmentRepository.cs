using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IInvestmentRepository
    {
        Task<Investment> GetInvestmentAsync(string id);
        Task<Investment> GetInvestmentAsync(Expression<Func<Investment, bool>> expression);
        Task<IEnumerable<Investment>> GetInvestmentAsync();
    }
}
