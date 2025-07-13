namespace SportReserveServer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> Get(int id);
        Task<List<T>> Get();
        Task Add(T entity);
        Task Remove(T entity);
    }
}
