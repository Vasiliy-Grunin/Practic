using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    /// <summary>
    /// People Model
    /// </summary>
    public class PeopleDto
    {
        public PeopleDto(string name, string lastname, string patronymic)
        {
            Name = name;
            LastName = lastname;
            Patronymic = patronymic;
        }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }
    }
}
