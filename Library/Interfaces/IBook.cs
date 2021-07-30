using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Interface
{
    interface IBook
    {
        string Title { get; set; }
        string Author { get; set; }
        string Genre { get; set; }
    }
}
