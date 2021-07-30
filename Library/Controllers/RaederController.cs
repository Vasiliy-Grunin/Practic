using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class ReaderController : Controller
    {
        private static readonly List<Models.ReaderDto> _readers = new()
        {
            new Models.ReaderDto
            {
                Reader = new Models.PeopleDto() { Name = "Vasya", LastName = "Grunin", Patronymic = "Nic" }
            ,
                Book = new Models.BookDto() { Author = "Andry Parcis", Title = "Wear", Genre = "detective" }
            ,
                DateTimeOffset = DateTime.UtcNow
            }
        };

        /// <summary>
        /// Create list reader
        /// </summary>
        /// <returns></returns>
        [HttpGet("Readers")]
        public List<Models.ReaderDto> GetReaders()
        {
            return _readers;
        }

        /// <summary>
        /// Create list reader where Name reader equals input name 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("{name}")]
        public List<Models.ReaderDto> GetReaders(string name)
        {
            return _readers
                .Where(reader => reader.Reader.Name.Equals(name, StringComparison.InvariantCulture))
                .Select(reader => reader)
                .ToList();
        }

        /// <summary>
        /// Add Reader
        /// </summary>
        /// <param name="reader"></param>
        [HttpPost("Reader")]
        public void AddReader([FromBody][Bind] Models.ReaderDto reader)
        {
            if (ModelState.IsValid)
                _readers.Add(reader);
        }

        /// <summary>
        /// Delete input reader
        /// </summary>
        /// <param name="reader"></param>
        [HttpDelete("Delete/Reader")]
        public void DeleteReader([FromBody][Bind] Models.ReaderDto reader)
        {
            if (ModelState.IsValid)
                _readers.Remove(reader);
        }
    }
}
