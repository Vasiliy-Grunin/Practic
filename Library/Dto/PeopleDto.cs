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
    /// People Model
    /// </summary>
    
    public class PeopleDto : IEquatable<PeopleDto>, IPeople
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Patronymic { get; set; }

        public bool Equals(PeopleDto other) => Name == other.Name
                && LastName == other.LastName
                && Patronymic == other.Patronymic;

        public override bool Equals(object obj)
            => Equals(obj as PeopleDto);

        public override string ToString()
            => string.Format("{0} {1} {2}", LastName, Name, Patronymic);

        public override int GetHashCode() => Name.GetHashCode()
                                             ^ LastName.GetHashCode()
                                             ^ Patronymic.GetHashCode();

        public PeopleModel ToModel()
            => new()
            {
                Name = Name,
                LastName = LastName,
                Patronymic = Patronymic
            };
    }
}
