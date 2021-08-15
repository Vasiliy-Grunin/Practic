﻿using Library.DAL.Entitys.Dto;
using Library.DAL.Service.UnityOfwork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.PAL.Controllers
{
    public class GenryController : Controller
    {
        public GenryController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// Get all genry
        /// </summary>
        /// <returns>List uniqlo genry</returns>
        [HttpGet("GenryDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GenryDto>> GetGenry()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            return Ok(service.Genrys.Get());
        }

        /// <summary>
        /// Get statistic
        /// </summary>
        /// <returns></returns>
        [HttpGet("GenryDto/Statistic")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dictionary<string, int>> GetStatistics()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            return Ok(service.Genrys.GetStatistic());
        }

        /// <summary>
        /// Create the genry
        /// </summary>
        /// <returns>status</returns>
        [HttpPost("GenryDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GenryDto> Add(GenryDto genry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.ToString());

            service.Genrys.Add(genry);
            return Ok(genry);
        }
    }
}
