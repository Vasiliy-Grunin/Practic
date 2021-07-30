using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Interface
{
    interface IPeople
    {
        string Name { get; set; }
        string LastName { get; set; }
        string Patronymic { get; set; }
    }
}
