using Library.DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace Library.DAL.Entitys.Model
{
    public class BookModel : IRecord, IBook<AuthorModel,GenryModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual AuthorModel Author { get; set; }

        public virtual List<GenryModel> Genre { get; set; }

        public virtual List<PeopleModel> Master { get; set; }
    }
}
