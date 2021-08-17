using System;

namespace Library.DAL.Entitys.Interfaces
{
    interface IInheritance
    {
        DateTime DateTimeAdd { get; set; }
        DateTime DateTimeChange { get; set; }
        int Version { get; set; }
    }
}
