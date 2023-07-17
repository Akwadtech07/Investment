using New_folder.Models.Entities;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IInvestmentTypeRepository
    {
        Task<InvestmentType> GetInvestmentTypeAsync(string id);
        Task<InvestmentType> GetInvestmentTypeAsync(Expression<Func<InvestmentType, bool>> expression);
        Task<IEnumerable<InvestmentType>> GetInvestmentTypeAsync();
    }
}
