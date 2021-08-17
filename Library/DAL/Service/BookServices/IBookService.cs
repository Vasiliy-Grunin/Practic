using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.BookServices
{
    public interface IBookService : IRepository<BookModel, BookDto>
    {
    }
}