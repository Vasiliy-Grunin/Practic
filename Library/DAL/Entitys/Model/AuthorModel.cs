using Library.DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace Library.DAL.Entitys.Model
{
    public class AuthorModel : IRecord, IPeople
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string MidleName { get; set; }

        public List<BookModel> Books { get; set; } = new List<BookModel>();
    }
}
