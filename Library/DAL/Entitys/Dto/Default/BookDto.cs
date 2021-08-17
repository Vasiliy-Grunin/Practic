using Library.DAL.Entitys.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entitys.Dto.Default
{
    public class BookDto : IBook
    {
        [Required]
        [StringLength(50, ErrorMessage = "the name is too long", MinimumLength = 1)]
        public string Title { get; set; }
    }
}
