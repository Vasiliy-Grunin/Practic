using Library.DAL.Entitys.Interfaces;
using System;

namespace Library.DAL.Entitys.Model.Inheritance
{
    public class BookInheritance : BookModel, IInheritance
    {
        public DateTime DateTimeAdd { get; set; }
        public DateTime DateTimeChange { get; set; }
        public int Version { get; set; }
    }
}
