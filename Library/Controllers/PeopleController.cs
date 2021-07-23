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
        public PeopleController(Data.ApplicationDbContext context)
        {
            _db = context;
        }

        private readonly Data.ApplicationDbContext _db;

        // GET: PeopleController/Details/5
        /// <summary>
        /// Get all people where name is input name
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        [HttpGet("PeopleDto/{Name}")]
        public List<Models.PeopleDto> GetPeople(string Name)
        {
            return _db.Peoples
                .Where(x => x.Name.Equals(Name, StringComparison.InvariantCulture))
                .Select(x => x)
                .ToList();
        }

        // GET: PeopleController/Create
        /// <summary>
        /// Get all people
        /// </summary>
        /// <returns></returns>
        [HttpGet("PeopleDto/")]
        public List<Models.PeopleDto> GetAllPeople()
        {
            return _db.Peoples.ToList();
        }

        // GET: PeopleController/Delete/5
        /// <summary>
        /// delete person
        /// </summary>
        /// <returns>status</returns>
        [HttpDelete("PeopleDto/NameLastNamePatronymic")]
        public void Delete([FromBody][Bind("LastName,Name,Patronymic")] Models.PeopleDto people)
        {
            if(ModelState.IsValid)
            {
                var deletePerson = _db.Peoples
                .Where(person => person.Name == people.Name
                && person.LastName == people.LastName
                && person.Patronymic == people.Patronymic);
                _db.RemoveRange(deletePerson);
                _db.SaveChanges();

            }
        }

        /// <summary>
        /// add new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("PeopleDto/LastNameNamePatronymic")]
        public void AddPerson([FromBody][Bind("LastName,Name,Patronymic")] Models.PeopleDto people)
        {
            if(ModelState.IsValid)
            { 
                _db.Peoples.Add(people);
                _db.SaveChanges();
            }
        }
    }
}
