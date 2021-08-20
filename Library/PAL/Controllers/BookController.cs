using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Library.DAL.Service.UnityOfwork;
using Library.DAL.Entitys.Dto.Default;

namespace Library.PAL.Controllers
{
    public class BookController : Controller
    {
        public BookController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// create new list book according to the specified criterion
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("book/{title}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<BookDto>> GetBooks(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title is null or whiteSpace");

            return Ok(service.Books.Get(title));
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
            return Ok(service.Books.Get());
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
                return BadRequest(ModelState);

            service.Books.Add(book);
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
                return BadRequest(ModelState);

            service.Books.Remove(book);
            return Ok();
        }
    }
}
