﻿namespace Investra_DAL.Repositories.GenericRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> Delete(Guid id);
        Task<TEntity> Update(TEntity entity);
        Task SaveAsync();
    }
}
