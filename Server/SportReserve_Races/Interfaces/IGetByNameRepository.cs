using SportReserve_Races_Db.Entities;

namespace SportReserve_Races.Interfaces
{
    public interface IGetByNameRepository
    {
        Task<Race?> Get(string name);
    }
}
