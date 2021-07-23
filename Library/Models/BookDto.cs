using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Book Model
    /// </summary>
    
    public class BookDto : IEquatable<BookDto>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "the name is too long", MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Author { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "the genre is too long", MinimumLength = 1)]
        public string Direction { get; set; }

        public bool Equals(BookDto other)
        {
            return other.Name == Name
                && other.Author == Author
                && other.Direction == Direction;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BookDto);
        }

        public override int GetHashCode() => Id.GetHashCode()
                                             ^ Name.GetHashCode()
                                             ^ Author.GetHashCode()
                                             ^ Direction.GetHashCode();

        public override string ToString()
        {
            return string.Format("{0} - {1} {2} {3}",Id,Name,Author,Direction).ToString();
        }
    }
}
