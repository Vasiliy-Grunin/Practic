using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.AuthorServices
{
    public class AuthorService : GynericRepository<AuthorModel,AuthorDto>, IAuthorService
    {
        public AuthorService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public override bool Remove(AuthorDto author)
        {
            return true;
        }
    }
}
