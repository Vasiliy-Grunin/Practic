using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using System.Collections.Generic;

namespace Library.DAL.Service.GenryServices
{
    public class GenryService : GynericRepository<GenryModel,GenryDto>, IGenryService
    {
        public GenryService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public Dictionary<string, int> GetStatistic()
        {
            return new Dictionary<string, int>();
        }
    }
}
