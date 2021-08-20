using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using System.Collections.Generic;

namespace Library.DAL.Service.ReaderServices
{
    public interface IReaderService : IRepository<PeopleModel, PersonDto>
    {
        public IEnumerable<Entitys.Dto.ReaderDto> GetLibraryCard();
        public bool RemoveBook(PersonDto entity, BookDto book);
        public bool UpdateBook(PersonDto entity, Entitys.Dto.BookDto book);
    }
}
