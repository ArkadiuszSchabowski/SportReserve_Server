using AutoMapper;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Models.Race;

namespace SportReserve_Users
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Race, GetRaceDto>();
            CreateMap<AddRaceDto, Race>();
            CreateMap<UpdateRaceDto, Race>();
            CreateMap<RaceTrace, GetRaceTraceDto>();
            CreateMap<AddRaceTraceDto, RaceTrace>();
        }
    }
}
