using AutoMapper;
using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;
using System.Linq;

namespace Library.DAL.Service.MappingService
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<BookModel, Entitys.Dto.Default.BookDto>(MemberList.Destination)
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<GenryModel, Entitys.Dto.Default.GenryDto>(MemberList.Destination)
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<AuthorModel, Entitys.Dto.Default.AuthorDto>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName));

            CreateMap<PeopleModel, Entitys.Dto.Default.PersonDto>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName))
                .ForMember(dst => dst.Birthday, opt => opt.MapFrom(src => src.Birthday));

            CreateMap<Entitys.Dto.Default.BookDto, BookModel>(MemberList.Destination)
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.Title));

            CreateMap<Entitys.Dto.Default.GenryDto, GenryModel>(MemberList.Destination)
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Entitys.Dto.Default.AuthorDto, AuthorModel>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName));

            CreateMap<Entitys.Dto.Default.PersonDto, PeopleModel>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName))
                .ForMember(dst => dst.Birthday, opt => opt.MapFrom(src => src.Birthday));

            CreateMap<GenryModel, GenryDto>(MemberList.Destination)
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.Books, opt => opt.MapFrom(src => src.Books.Select(x => x.Title)));

            CreateMap<PeopleModel, ReaderDto>(MemberList.Destination)
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dst => dst.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dst => dst.MidleName, opt => opt.MapFrom(src => src.MidleName))
                .ForMember(dst => dst.Birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dst=>dst.Books,opt=>opt.MapFrom(src=>src.Books.Select(x=>x.Title)));
        }
    }
}
