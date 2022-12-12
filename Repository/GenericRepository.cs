using Akvelon_Task_Manager.Contracts;
using Akvelon_Task_Manager.Data;
using Microsoft.EntityFrameworkCore;

namespace Akvelon_Task_Manager.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class  // Inheriting from igeneric repository with generics <T>
    {                                                                          // to be able to apply this methods to many classes
        private readonly AkvelonTaskManagerDbContext _context;
        public GenericRepository(AkvelonTaskManagerDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async System.Threading.Tasks.Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int? id)
        {
            if (id is null) return null;

            return await _context.Set<T>().FindAsync(id);
        }

        public async System.Threading.Tasks.Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}