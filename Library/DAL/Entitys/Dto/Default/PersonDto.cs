using Library.DAL.Entitys.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.DAL.Entitys.Dto.Default
{
    /// <summary>
    /// People Model
    /// </summary>
    
    [DataContract]
    public class PersonDto : IEquatable<PersonDto>, IPeople, IPerson, IDto
    {
        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }

        [Required]
        [StringLength(50,MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1)]
        public string MidleName { get; set; }
        
        [Required]
        public DateTime Birthday { get; set; }

        public bool Equals(PersonDto other) => Name == other.Name
                && LastName == other.LastName
                && MidleName == other.MidleName;

        public override bool Equals(object obj)
            => Equals(obj as PersonDto);

        public override string ToString()
            => string.Format("{{0}} {{1}} {{2}} {{4}}", LastName, Name, MidleName, Birthday);

        public override int GetHashCode() => Name.GetHashCode()
                                             ^ LastName.GetHashCode()
                                             ^ MidleName.GetHashCode();
    }
}
