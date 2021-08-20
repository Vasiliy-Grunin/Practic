using Library.DAL.Service.AuthorServices;
using Library.DAL.Service.BookServices;
using Library.DAL.Service.GenryServices;
using Library.DAL.Service.ReaderServices;

namespace Library.DAL.Service.UnityOfwork
{
    public interface IUnityOfWork
    {
        IReaderService Readers { get; }
        IGenryService Genrys { get; }
        IAuthorService Authors { get; }
        IBookService Books { get; }

        int Complete();
    }
}
