using System.Collections.Generic;

namespace Library.DAL.Entitys.Interfaces
{
    interface IGenry<TBook>
        where TBook : class
    {
        public string Name { get; set; }

        public List<TBook> Books { get; set; }
    }
}
