namespace SportReserve_Races.Interfaces
{
    public interface IUpdate<T> where T : class
    {
        Task Update(int id, T dto);
    }
}
