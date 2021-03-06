using Library.DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace Library.DAL.Entitys.Model
{
    public class GenryModel : IRecord, IGenry<BookModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<BookModel> Books { get; set; }
    }
}
