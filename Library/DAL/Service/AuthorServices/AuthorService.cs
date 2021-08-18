using AutoMapper;
using Library.DAL.Data;
using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using System.Collections.Generic;
using System.Linq;

namespace Library.DAL.Service.AuthorServices
{
    public class AuthorService : GynericRepository<AuthorModel, AuthorDto>, IAuthorService
    {
        public AuthorService(LibraryDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public override bool Remove(AuthorDto author)
        {
            if (GetEntity(author).Books.Any())
                return false;

            return base.Remove(author);
        }

        public override bool Remove(int id)
        {
            if (GetEntity(id).Books.Any())
                return false;

            return base.Remove(id);
        }

        public override bool RemoveRange(IEnumerable<AuthorDto> entitys)
        {
            if (GetEntities(entitys)
                .Select(entity => entity.Books.Any())
                .Any())
                return false;

            return base.RemoveRange(entitys);
        }
    }
}
