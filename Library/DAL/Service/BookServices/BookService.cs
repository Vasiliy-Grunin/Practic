using Library.DAL.Data;
using Library.DAL.Entitys.Model;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Service.GynericRepositorys;
using AutoMapper;

namespace Library.DAL.Service.BookServices
{
    public class BookService : GynericRepository<BookModel, BookDto>, IBookService
    {
        public BookService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
