using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Entitys.Dto
{
    public class ReaderDto : Default.PersonDto
    {
        public List<Default.BookDto> Books { get; set; }
    }
}
