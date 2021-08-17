using Library.DAL.Service.UnityOfwork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Library.DAL.Entitys.Dto.Default;

namespace Library.PAL.Controllers
{
    public class AuthorController : Controller
    {
        public AuthorController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// Get all author where name is input name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("PeopleDto/{Name}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<AuthorDto>> GetPeople(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(@"\d+"))
                return BadRequest("name is null");

            return Ok(service.Authors.Get(name));
        }

        /// <summary>
        /// Get all autthors
        /// </summary>
        /// <returns></returns>
        [HttpGet("AuthorDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<AuthorDto>> GetAllPeople()
        {
            return Ok(service.Authors.Get());
        }

        /// <summary>
        /// delete author
        /// </summary>
        /// <returns>status</returns>
        [HttpDelete("AuthorDto/NameLastNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AuthorDto> Delete([FromBody][Bind("LastName,Name,MidleName")] AuthorDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            service.Authors.Remove(author);
            return Ok(author);
        }

        /// <summary>
        /// add new author
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("AuthorDto /LastNameNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AuthorDto> AddPerson([FromBody][Bind("LastName,Name,MidleName")] AuthorDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            service.Authors.Add(author);
            return Ok(author);
        }
    }
}
