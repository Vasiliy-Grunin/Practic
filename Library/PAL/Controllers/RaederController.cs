using Library.DAL.Entitys.Dto.Default;
using Library.DAL.Service.UnityOfwork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.PAL.Controllers
{
    public class ReaderController : Controller
    {
        public ReaderController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// Get all author where name is input name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Readers which have a input name</returns>
        [HttpGet("PersonDto/{Name}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PersonDto>> GetPeople(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(@"\d+"))
                return BadRequest("name is null");

            return Ok(service.Readers.Get(name));
        }

        /// <summary>
        /// Get all autthors
        /// </summary>
        /// <returns>All rreaders</returns>
        [HttpGet("PersonDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<PersonDto>> GetAllPeople()
        {
            return Ok(service.Readers.Get());
        }

        /// <summary>
        /// elete reader
        /// </summary>
        /// <returns>reader</returns>
        [HttpDelete("PersonDto/NameLastNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonDto> Delete([FromBody][Bind("LastName,Name,MidleName")] PersonDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            service.Readers.Remove(people);
            return Ok(people);
        }

        /// <summary>
        /// Add new reader
        /// </summary>
        /// <param name="person"></param>
        /// <returns>raeder</returns>
        [HttpPost("PersonDto/LastNameNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PersonDto> AddPerson([FromBody][Bind("LastName,Name,MidleName")] PersonDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            service.Readers.Add(people);
            return Ok(people);
        }
    }
}
