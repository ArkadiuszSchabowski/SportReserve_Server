using AutoMapper;
using SportReserveDatabase.Entities;
using SportReserveServer.Models;

namespace SportReserveServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<AddUserDto, User>();
        }
    }
}
