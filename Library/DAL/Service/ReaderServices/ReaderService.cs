using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.ReaderServices
{
    public class ReaderService : GynericRepository<PeopleModel,PersonDto>, IReaderService
    {
        public ReaderService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        { 
        }
    }
}
