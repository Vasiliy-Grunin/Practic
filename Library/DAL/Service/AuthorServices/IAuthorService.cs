using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.AuthorServices
{
    public interface IAuthorService: IRepository<AuthorModel, AuthorDto>
    {
    }
}
