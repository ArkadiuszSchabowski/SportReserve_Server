using AutoMapper;
using SportReserve_Shared.Models;
using SportReserveDatabase.Entities;

namespace SportReserveServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<RegisterDto, User>();
        }
    }
}
