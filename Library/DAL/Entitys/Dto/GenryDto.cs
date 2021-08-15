using Library.DAL.Entitys.Interfaces;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.DAL.Entitys.Dto
{
    [DataContract]
    public class GenryDto : IGenry<BookDto>
    {
        public string Name { get; set; }
        public virtual List<BookDto> Books { get; set; }
    }
}