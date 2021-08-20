using Library.DAL.Entitys.Interfaces;

namespace Library.DAL.Entitys.Dto.Default
{
    public class GenryDto : IGenry, IDto
    {
        public string Name { get; set; }
    }
}
