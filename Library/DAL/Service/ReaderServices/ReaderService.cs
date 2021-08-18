using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Service.ReaderServices
{
    public class ReaderService : GynericRepository<PeopleModel,PersonDto>, IReaderService
    {
        public ReaderService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        { 
        }

        public override bool Remove(PersonDto entity)
        {
            if (GetEntity(entity).Books.Any())
                return false;

            return base.Remove(entity);
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Books.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<PersonDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Books.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }
}
