using Library.DAL.Data;
using Library.DAL.Entitys.Model;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Service.GynericRepositorys;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Service.BookServices
{
    public class BookService : GynericRepository<BookModel, BookDto>, IBookService
    {
        public BookService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public override bool Remove(BookDto entity)
        {
            if (GetEntity(entity).Master.Count > 0)
                return false;

            return base.Remove(entity);
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Master.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<BookDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Master.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }
}
