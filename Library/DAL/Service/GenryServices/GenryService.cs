using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Service.GenryServices
{
    public class GenryService : GynericRepository<GenryModel,GenryDto>, IGenryService
    {
        public GenryService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public Dictionary<string, int> GetStatistic()
            => context.Genries
            .Include(entity => entity.Books)
            .ToDictionary(genry => genry.Name, genry => genry.Books.Count);
    }
}
