﻿using New_folder.Data;
using New_folder.Repositories.Interfaces;

namespace New_folder.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new();
    {
        protected ApplicationContext _context;

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public T UpdateAsync(T entity)
        {
            _context?.Set<T>().Update(entity);
            return entity;
        }
    }
}
