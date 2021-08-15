using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.BookServices
{
    public interface IBookService : IRepository<BookModel, BookDto>
    {
    }
}