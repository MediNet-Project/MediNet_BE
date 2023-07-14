using MediNet.Context;
using MediNet.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace MediNet.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(T entity)
        {
            //var filteredData = _dbContext.Set<T>().;
            //_dbContext.Set<T>().Remove(filteredData);
            //return await _dbContext.SaveChangesAsync();
            _dbContext.Set<T>().Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateAsync(T entity)
        {
            T exist = _dbContext.Set<T>().Find(entity);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);
            return await _dbContext.SaveChangesAsync();

        }
    }
}
