﻿

namespace Library.DAL.Entitys.Interfaces
{
    /// <summary>
    /// Requared field for a people
    /// </summary>
    interface IPeople
    {
        string Name { get; set; }
        string LastName { get; set; }
        string MidleName { get; set; }
    }
}
