using Library.DAL.Entitys.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.DAL.Entitys.Dto
{
    public class AuthorDto : Default.AuthorDto, IPeople, IAuthor<Default.BookDto>
    {
        public List<Default.BookDto> Books { get; set; }
    }
}
