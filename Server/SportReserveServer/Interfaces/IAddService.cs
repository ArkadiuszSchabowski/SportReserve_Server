namespace SportReserveServer.Interfaces
{
    public interface IAddService<T> where T : class
    {
        void Add(T dto);
    }
}
