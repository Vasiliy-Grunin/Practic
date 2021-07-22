using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private static readonly List<Models.BookDto> _books = new()
        {
            new Models.BookDto()
            {
                Author = "Year Tiger",
                Direction = "horror",
                Name = "Path"
            },
        };

        // GET: BookController
        /// <summary>
        /// create new list book according to the specified criterion
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("book/{Name}")]
        public List<Models.BookDto> GetBooks(string Name)
        {
            return _books.Where(x=>x.Name.Equals(Name)).Select(x=>x).ToList();
        }

        // GET: BookController/Details/5
        /// <summary>
        /// create list books
        /// </summary>
        /// <returns>all book</returns>
        [HttpGet("book/")]
        public List<Models.BookDto> GetBooks()
        {
            return _books;
        }

        // Post: BookController/Create
        /// <summary>
        /// create new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("book/{Author} {Name} {Direction}")]
        public void CreateNewBook([FromBody]Models.BookDto book)
        {
            _books.Add(book);
        }

        // POST : BookController/Delete/5
        /// <summary>
        /// delete book on this name and author.
        /// </summary>
        [HttpDelete("book/{Name}, {Author}")]
        public void Delete(string Name, string Author)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Author == Author && _books[i].Name == Name)
                    _books.Remove(_books[i]);
            }
        }
    }
}
