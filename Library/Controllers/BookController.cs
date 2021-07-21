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
                Author = "",
                Direction = "",
                Name = ""
            },
        };

        // GET: BookController
        [HttpGet("book/{Name}")]
        public List<Models.BookDto> GetBooks(string Name)
        {
            return _books.Where(x=>x.Name.Equals(Name)).ToList();
        }

        // GET: BookController/Details/5
        [HttpGet("book/")]
        public List<Models.BookDto> GetBooks()
        {
            return _books;
        }

        // Post: BookController/Create
        [HttpPost("book/{Author} {Name} {Direction}")]
        public int CreateNewBook([FromBody]Models.BookDto book)
        {
            _books.Add(book);
            return 201;
        }

        // POST : BookController/Delete/5
        /// <summary>
        /// delete book on this name.
        /// </summary>
        [HttpDelete("book/{Name}, {Author}")]
        public int Delete(string Name, string Author)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].Author == Author && _books[i].Name == Name)
                    _books.Remove(_books[i]);
            }
            return 201;
        }
    }
}
