using System.Collections.Generic;

namespace Library.DAL.Entitys.Interfaces
{
    /// <summary>
    /// Required fields for BookModel
    /// </summary>
    /// <typeparam name="TAuthor">The reprisentor a AuthorModel</typeparam>
    /// <typeparam name="EGenry">The reprisentor a GenryModel</typeparam>
    interface IBook<TAuthor, EGenry>
        where TAuthor : IPeople
        where EGenry : class
    {
        string Title { get; set; }
        TAuthor Author { get; set; }
        List<EGenry> Genre { get; set; }
    }
}
