using Library.DAL.Entitys.Interfaces;
using System.Collections.Generic;

namespace Library.DAL.Entitys.Model
{
    public class BookModel : IRecord, IBook<AuthorModel,GenryModel>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public AuthorModel Author { get; set; }

        public List<GenryModel> Genre { get; set; } = new List<GenryModel>();

        public List<PeopleModel> Master { get; set; } = new List<PeopleModel>();
    }
}
