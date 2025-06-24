namespace SportReserveServer.Interfaces
{
    public interface IGetService<T> where T : class
    {
        Task<T> Get(int id);
        Task<List<T>> Get();
    }
}
