using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IInvestorRepository : IBaseRepository<Investor>
    {
        Task<Investor> GetInvestorAsync(string id);
        Task<Investor> GetInvestorAsync(Expression<Func<Investor, bool>> expression);
        Task<IEnumerable<Investor>> GetInvestorAsync();
        Task<IEnumerable<Investor>> GetAllInvestorAsync();
        
    }
}
