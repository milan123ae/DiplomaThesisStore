using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseAccess;
using DatabaseAccess.DTOs;
using Microsoft.AspNetCore.Http;


namespace Diplomski.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiStudente/{idSmera}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetStudenti(int idSmera)
        {
            try
            {
                return new JsonResult(DataProvider.VratiStudenteSmer(idSmera));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiSveStudente")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSviStudenti()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveStudente());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajStudenta/{IdSmera}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddStudentWithSmera([FromRoute(Name = "idSmera")] int idSmera, [FromBody] StudentView o)
        {
            try
            {
                var smer = DataProvider.VratiSmer(idSmera);
                o.UpisaoSmerr = smer;
                DataProvider.DodajStudenta(o);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniStudenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeStudent([FromBody] StudentView o)
        {
            try
            {
                DataProvider.UpdateStudent(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiStudenta/{Email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteStudent(string Email)
        {
            try
            {
                DataProvider.ObrisiStudenta(Email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
