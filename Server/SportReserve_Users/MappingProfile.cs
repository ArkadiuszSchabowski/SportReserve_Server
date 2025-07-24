using AutoMapper;
using SportReserve_Shared.Models.User;
using SportReserve_Users_Db;
using SportReserve_Users_Db.Entities;

namespace SportReserve_Users
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<RegisterDto, User>();
            CreateMap<User, UserRegisteredEventDto>();
        }
    }
}
