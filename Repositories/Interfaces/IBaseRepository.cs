using New_folder.Data;
using System.Linq.Expressions;

namespace New_folder.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        T UpdateAsync(T entity);
        bool Exists(Expression<Func<T, bool>> expression);
        Task<int> SaveChangesAsync();

    }
}
