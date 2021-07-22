using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class PeopleController : Controller
    {
        private static readonly List<Models.PeopleDto> _peoples = new() 
        {
            new Models.PeopleDto("Vasya", "Grunin", "Nik"),
                new Models.PeopleDto("Gena", "Punin", "Nik"),
                new Models.PeopleDto("Arkadiy", "Dunin", "Nik"),
        };

        // GET: PeopleController/Details/5
        /// <summary>
        /// Get all people where name is input name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("People/{Name}")]
        public List<Models.PeopleDto> GetPeople(string Name)
        {
            return _peoples.Where(x=>x.Name.Equals(Name)).Select(x=>x).ToList();
        }

        // GET: PeopleController/Create
        /// <summary>
        /// Get all people
        /// </summary>
        /// <returns></returns>
        [HttpGet("People/")]
        public List<Models.PeopleDto> GetAllPeople()
        {
            return _peoples;
        }

        // GET: PeopleController/Delete/5
        /// <summary>
        /// delete person
        /// </summary>
        /// <param name="id"></param>
        /// <returns>status</returns>
        [HttpDelete("People/{Name} {LastName} {Pathronymic}")]
        public void Delete([FromBody] string Name, string LastName, string Pathronymic)
        {
            _peoples.Remove(new Models.PeopleDto(Name,LastName,Pathronymic));
        }

        /// <summary>
        /// add new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("People/{Name} {LastName} {Patronymic}")]
        public void AddPerson([FromBody] string Name, string LastName, string Patronymic)
        {
            _peoples.Add(new Models.PeopleDto(Name, LastName, Patronymic));
        }
    }
}
