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
    public class AngazovanNaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveAngazovanNa")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAngazovanNa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveAngazovanNa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("PoveziNastavnikaIPredmet/{Email}/{predmetID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult LinkNastavnikToPredmet(string Email, int predmetID)
        {
            try
            {
                var nastavnik = DataProvider.VratiNastavnoOsoblje(Email);
                var predmet = DataProvider.VratiPredmet(predmetID);
                var povezi = new AngazovanNaView { Angazovanje = nastavnik, Angazovan = predmet };
                DataProvider.SacuvajAngazovanNa(povezi);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiAngazovanNa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteAngazovanNa(int id)
        {
            try
            {
                DataProvider.ObrisiAngazovanNa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

