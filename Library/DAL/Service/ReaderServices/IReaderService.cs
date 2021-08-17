using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;

namespace Library.DAL.Service.ReaderServices
{
    public interface IReaderService : IRepository<PeopleModel, PersonDto>
    {
    }
}
