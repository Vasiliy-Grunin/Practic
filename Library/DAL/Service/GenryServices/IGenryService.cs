using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Entitys.Model;
using Library.DAL.Service.GynericRepositorys;
using System.Collections.Generic;

namespace Library.DAL.Service.GenryServices
{
    public interface IGenryService: IRepository<GenryModel,GenryDto>
    {
        Dictionary<string,int> GetStatistic();
    }
}
