using New_folder.Data;

namespace New_folder.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        T UpdateAsync(T entity);
        Task<int> SaveChangesAsync();

    }
}
