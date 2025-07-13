namespace SportReserve_Shared.Interfaces
{
    public interface IAddService<T> where T : class
    {
        Task Add(T dto);
    }
}
