using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Library.LogicDb;
using Microsoft.AspNetCore.Http;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        public BookController(ApplicationDbContext context)
        {
            books = new Connection<BookModel>(context);
        }

        private readonly Connection<BookModel> books;

        /// <summary>
        /// create new list book according to the specified criterion
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("book/{Name}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<BookDto>> GetBooks(string name)
        {
            return Ok(books.Get(name)
                .Select(book => new BookDto() { Author = book.Author, Genre = book.Genre, Title = book.Title })
                .ToList());
        }

        /// <summary>
        /// create list books
        /// </summary>
        /// <returns>all book</returns>
        [HttpGet("book/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<BookDto>> GetBooks()
        {
            return Ok(books.Get()
                .Select(book => new BookDto() { Author = book.Author, Genre = book.Genre, Title = book.Title })
                .ToList());
        }

        /// <summary>
        /// create new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("book/AuthorNameDirection/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult CreateBook([FromBody][Bind("Author,Name,Direction")] BookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            books.Add(book.ToModel());
            return Ok();

        }

        /// <summary>
        /// delete book on this name and author.
        /// </summary>
        [HttpDelete("book/NameAuthor/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete([FromBody][Bind("Author,Name,Direction")] BookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            books.Delete(book.ToModel());
            return Ok();
        }
    }
}
