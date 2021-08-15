using Library.DAL.Entitys.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Library.DAL.Entitys.Dto
{
    [DataContract]
    public class AuthorDto : IPeople, IEquatable<AuthorDto>
    {
        [Required]
        public virtual string Name { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        [Required]
        public virtual string MidleName { get; set; }

        public bool Equals(AuthorDto other)
        {
            return Name.Equals(other.Name)
                && LastName.Equals(other.LastName)
                && MidleName.Equals(other.MidleName);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name,LastName,MidleName);
        }

        public override string ToString()
            => string.Format("{0} {1} {2}", Name, LastName, MidleName);
    }
}