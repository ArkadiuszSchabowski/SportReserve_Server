namespace SportReserveServer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        List<T> Get();
        void Add(T entity);
        void Remove(T entity);
    }
}
