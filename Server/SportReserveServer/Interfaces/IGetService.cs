namespace SportReserveServer.Interfaces
{
    public interface IGetService<T> where T : class
    {
        T Get(int id);
        List<T> Get();
    }
}
