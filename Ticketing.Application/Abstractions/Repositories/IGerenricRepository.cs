namespace Ticketing.Application.Abstractions.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
        void Update(T entity);
        void Delete(T entity);
    }
}
