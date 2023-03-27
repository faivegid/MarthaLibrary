using AutoMapper;
using marthaLibrary.CoreData.DatabaseModels;
using marthaLibrary.CoreData.Enums;
using marthaLibrary.Models.DTOs;

namespace marthaLibrary.Config.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRole, string>()
               .ConvertUsing(src => src.ToString());

            CreateMap<string, UserRole>()
            .ConvertUsing(src => (UserRole)Enum.Parse(typeof(UserRole), src));

            CreateMap<BookStatus, string>()
               .ConvertUsing(src => src.ToString());

            CreateMap<string, BookStatus>()
            .ConvertUsing(src => (BookStatus)Enum.Parse(typeof(BookStatus), src));

            CreateMap<AppUser, UserDto>()
                .ReverseMap();

            CreateMap<AppUser, UserInfoDto>()
                .ReverseMap();

            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.BookStatus, src => src.MapFrom(x => x.Status))
                .ReverseMap();
        }
    }
}
