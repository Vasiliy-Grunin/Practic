using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Library.Models.Interface;

namespace Library.Models
{
    /// <summary>
    /// Book Model
    /// </summary>
    
    public class BookDto : IEquatable<BookDto>, IBook
    {
        [Required]
        [StringLength(50, ErrorMessage = "the name is too long", MinimumLength = 1)]
        public string Title { get; set; }

        [Required]
        [StringLength(150)]
        public string Author { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "the genre is too long", MinimumLength = 1)]
        public string Genre { get; set; }

        public bool Equals(BookDto other) => other.Title == Title
                && other.Author == Author
                && other.Genre == Genre;

        public override bool Equals(object obj)
            => Equals(obj as BookDto);

        public override int GetHashCode() => Title.GetHashCode()
                                             ^ Author.GetHashCode()
                                             ^ Genre.GetHashCode();

        public override string ToString()
            => string.Format("{0} {1} {2}", Title, Author, Genre);

        public BookModel ToModel()
            => new()
            {
                Title = Title,
                Author = Author,
                Genre = Genre
            };
    }
}
