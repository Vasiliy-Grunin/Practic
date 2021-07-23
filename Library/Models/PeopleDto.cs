using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    /// <summary>
    /// People Model
    /// </summary>
    
    public class PeopleDto : IEquatable<PeopleDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public bool Equals(PeopleDto other)
        {
            return Name == other.Name
                && LastName == other.LastName
                && Patronymic == other.Patronymic;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as PeopleDto);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Id, LastName, Name, Patronymic);
        }

        public override int GetHashCode() => Id.GetHashCode()
                                             ^ Name.GetHashCode()
                                             ^ LastName.GetHashCode()
                                             ^ Patronymic.GetHashCode();
    }
}
