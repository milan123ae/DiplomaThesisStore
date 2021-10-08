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
    public class AdministracijaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiAdministracije")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAdministracije()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveAdministracije());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajAdministraciju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddAdministracija([FromBody] AdministracijaView p)
        {
            try
            {
                DataProvider.DodajAdministraciju(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajLogovanje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddLogovanje([FromBody] AdministracijaView p)
        {
            try
            {
                AdministracijaView admin = DataProvider.VratiAdministraciju(p.Email);
                if (admin != null)
                {
                    if (admin.Password == p.Password)
                    {
                       return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniAdministraciju")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeAdministracija([FromBody] AdministracijaView p)
        {
            try
            {
                DataProvider.AzurirajAdministraciju(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiAdministraciju/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteSmer(string email)
        {
            try
            {
                DataProvider.ObrisiAdministraciju(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
