using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Service.AuthorServices;
using Library.DAL.Service.BookServices;
using Library.DAL.Service.GenryServices;
using Library.DAL.Service.ReaderServices;

namespace Library.DAL.Service.UnityOfwork
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly LibraryDbContext context;
        private readonly IMapper mapper;

        public UnitOfWork(LibraryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            Readers = new ReaderService (this.context,this.mapper);
            Genrys = new GenryService (this.context, this.mapper);
            Authors = new AuthorService (this.context, this.mapper);
            Books = new BookService (this.context, this.mapper);
        }

        public IReaderService Readers { get; private set; }

        public IGenryService Genrys { get; private set; }

        public IAuthorService Authors { get; private set; }

        public IBookService Books { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
