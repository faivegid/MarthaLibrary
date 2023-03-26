using AutoMapper;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.Models.DTOs;

namespace marthaLibrary.Config.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>()
                .ForMember(dest => dest.Role, src => src.MapFrom(x => x.Role.ToString()))
                .ReverseMap();
            
            CreateMap<AppUser, UserInfoDto>()
                .ForMember(dest => dest.Role, src => src.MapFrom(x => x.Role.ToString()))
                .ReverseMap();
        }
    }
}
