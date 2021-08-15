using AutoMapper;
using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;

namespace Library.DAL.Service.MappingService
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BookModel, BookDto>(MemberList.Destination)
                .ForMember(dst => dst.Author,
                opt => opt.MapFrom(
                    src => new AuthorDto()
                    {
                        LastName = src.Author.LastName,
                        Name = src.Author.Name,
                        MidleName = src.Author.MidleName
                    }))
                .ForMember(dst => dst.Genre,
                opt => opt.MapFrom(src => new GenryDto()
                {
                    Name = src.Genre.ToString()
                }))
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title));
            CreateMap<GenryModel, GenryDto>(MemberList.Destination)
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Books, opt => opt.MapFrom(src => src.Books));
            CreateMap<AuthorModel, AuthorDto>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName));
            CreateMap<PeopleModel, PersonDto>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName))
                .ForMember(dst => dst.Birthday, opt => opt.MapFrom(src => src.Birthday));
        }
    }
}
