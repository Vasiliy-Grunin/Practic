using System;
using Library.DAL.Entitys.Interfaces;

namespace Library.DAL.Entitys.Model.Inheritance
{
    public class PeopleInheritance : PeopleModel, IInheritance
    {
        public DateTime DateTimeAdd { get; set; }
        public DateTime DateTimeChange { get; set; }
        public int Version { get; set; }
    }
}
