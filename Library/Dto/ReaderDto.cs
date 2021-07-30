using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    /// <summary>
    /// Reader Moodel
    /// </summary>
    public class ReaderDto
    {
        [Required]
        public PeopleDto Reader { get; set; }

        [Required]
        public BookDto Book { get; set; }

        [Required]
        public DateTime DateTimeOffset { get; set; }
    }
}
