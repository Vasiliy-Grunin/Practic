using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Library.DAL.Entitys.Interfaces;

namespace Library.DAL.Entitys.Dto
{
    /// <summary>
    /// Book Model
    /// </summary>
    
    [DataContract]
    public class BookDto : IEquatable<BookDto>, IBook<AuthorDto,GenryDto>
    {
        [Required]
        [StringLength(50, ErrorMessage = "the name is too long", MinimumLength = 1)]
        public string Title { get; set; }
        public virtual AuthorDto Author { get; set; }
        public virtual List<GenryDto> Genre { get; set; }

        public bool Equals(BookDto other) => other.Title == Title
            && Author.Equals(other.Author)
            && Genre.Equals(other.Genre);

        public override bool Equals(object obj)
            => Equals(obj as BookDto);

        public override int GetHashCode() => Title.GetHashCode()
            ^ Author.GetHashCode()
            ^ Genre.GetHashCode();

        public override string ToString()
            => string.Format("{0} {1} {2}", Title, Author.ToString(), Genre.ToString());
    }
}
