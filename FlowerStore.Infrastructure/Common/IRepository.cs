namespace FlowerStore.Infrastructure.Common
{
    /// <summary>
    /// Interface for Repository. Repository will be used as database cobntext.
    /// </summary>
   
    public interface IRepository
    {
        IQueryable<T> All<T>() where T : class;
        IQueryable<T> AllAsReadOnly<T>() where T : class;
        Task AddAsync<T>(T entity) where T : class;
        Task<int> SaveChangesAsync();
    }
}