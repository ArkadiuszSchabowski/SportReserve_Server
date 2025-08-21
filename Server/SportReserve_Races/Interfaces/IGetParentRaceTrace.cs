using SportReserve_Races_Db.Entities;

namespace SportReserve_Races.Interfaces
{
    public interface IGetParentRaceTrace
    {
        Task<Race?> GetParent(int id);
    }
}
