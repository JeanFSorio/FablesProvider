using FablesProvider.Core;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FablesProvider.Database
{
    public class Repository : IRepository
    {
        private readonly FablesDbContext _dbContext;

        public Repository(FablesDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task Add<T>(T item) where T : DbEntityBase
        {
            await _dbContext.Set<T>().AddAsync(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete<T>(int id) where T : DbEntityBase
        {
            var itemToRemove = await _dbContext.Set<T>().FindAsync(id);
            if (itemToRemove != null)
            {
                _dbContext.Set<T>().Remove(itemToRemove);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task Edit<T>(T item) where T : DbEntityBase
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> Get<T>(int id) where T : DbEntityBase
        {
            return await _dbContext.Set<T>().FindAsync(id) ?? throw new ArgumentException("Id not found");
        }

        public async Task<IList<T>> GetAll<T>() where T : DbEntityBase
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
