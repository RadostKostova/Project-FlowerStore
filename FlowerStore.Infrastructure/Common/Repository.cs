namespace FlowerStore.Infrastructure.Common
{
    using FlowerStore.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    /// <summary>
    /// Repository will be used for database context.
    /// </summary>
    
    public class Repository : IRepository
    {
        private readonly DbContext dbContext;

        public Repository(FlowerStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        private DbSet<T> DbSet<T>() where T : class
        {
            return dbContext.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}