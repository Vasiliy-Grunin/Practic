using Library.LogicDb;
using Library.Models;
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
            peoples = new Connection<PeopleModel>(context);
        }

        private readonly Connection<PeopleModel> peoples;

        /// <summary>
        /// Get all people where name is input name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("PeopleDto/{Name}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeopleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PeopleDto>> GetPeople(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("name is null");

            return Ok(peoples.Get(name)
                .Select(people => new PeopleDto() {
                    Name = people.Name,
                    LastName = people.LastName,
                    Patronymic = people.Patronymic })
                .ToList());
        }

        /// <summary>
        /// Get all people
        /// </summary>
        /// <returns></returns>
        [HttpGet("PeopleDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeopleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PeopleDto>> GetAllPeople()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            return peoples.Get()
                .Select(people => new PeopleDto() {
                    Name = people.Name,
                    LastName = people.LastName,
                    Patronymic = people.Patronymic })
                .ToList();
        }

        /// <summary>
        /// delete person
        /// </summary>
        /// <returns>status</returns>
        [HttpDelete("PeopleDto/NameLastNamePatronymic/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeopleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete([FromBody][Bind("LastName,Name,Patronymic")] PeopleDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            peoples.Delete(people.ToModel());
            return Ok();
        }

        /// <summary>
        /// add new person
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("PeopleDto/LastNameNamePatronymic/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PeopleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult AddPerson([FromBody][Bind("LastName,Name,Patronymic")] PeopleDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            peoples.Add(people.ToModel());
            return Ok();
        }
    }
}
