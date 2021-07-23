using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        public BookController(Data.ApplicationDbContext context)
        {
            _db = context;
        }

        private readonly Data.ApplicationDbContext _db; 

        // GET: BookController
        /// <summary>
        /// create new list book according to the specified criterion
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("book/{Name}")]
        public List<Models.BookDto> GetBooks(string Name)
        {
            return _db.Books
                .Where(x => x.Name.Equals(Name,StringComparison.InvariantCulture))
                .Select(x => x)
                .ToList();
        }

        // GET: BookController/Details/5
        /// <summary>
        /// create list books
        /// </summary>
        /// <returns>all book</returns>
        [HttpGet("book/")]
        public List<Models.BookDto> GetBooks()
        {
            return _db.Books.ToList();
        }

        // Post: BookController/Create
        /// <summary>
        /// create new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("book/Author Name Direction")]
        public void CreateBook([FromBody][Bind("Author,Name,Direction")] Models.BookDto book)
        {
            if(ModelState.IsValid)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
            }
        }

        // POST : BookController/Delete/5
        /// <summary>
        /// delete book on this name and author.
        /// </summary>
        [HttpDelete("book/Name Author")]
        public void Delete([FromBody][Bind("Author,Name,Direction")] Models.BookDto book)
        {
            if(ModelState.IsValid)
            {
                _db.Books.Remove(book);
                _db.SaveChanges();
            }
        }
    }
}
