using Library.DAL.Entitys.Dto;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.ReaderServices
{
    public interface IReaderService : IRepository<PeopleModel, PersonDto>
    {
    }
}
