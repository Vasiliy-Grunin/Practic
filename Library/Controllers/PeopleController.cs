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
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("People/{name}")]
        public List<Models.PeopleDto> GetPeople(string name)
        {
            return _peoples.Where(x=>x.Equals(name)).ToList();
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
        [HttpDelete("People/{Peaple}")]
        public void Delete(Models.PeopleDto People)
        {
            _peoples.Remove(People);
        }

        /// <summary>
        /// add new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("People{Name, LastName, Patronymic}")]
        public ActionResult AddPerson([FromBody] string Name, string LastName, string Patronymic)
        {
            return View();
        }
    }
}
