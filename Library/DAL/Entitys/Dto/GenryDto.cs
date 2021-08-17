using Library.DAL.Entitys.Interfaces;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Library.DAL.Entitys.Dto
{
    [DataContract]
    public class GenryDto : Default.GenryDto, IGenry<Default.BookDto>
    {
        public virtual List<Default.BookDto> Books { get; set; }
    }
}