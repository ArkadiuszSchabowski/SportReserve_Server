using SportReserve_Shared.Models.Race;

namespace SportReserve_Races.Interfaces
{
    public interface IGetByName
    {
        Task<GetRaceDto> GetByName(string name);
    }
}
