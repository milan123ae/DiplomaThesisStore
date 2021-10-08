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
    public class UciNaController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveUciNa")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetUciNa()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveUciNa());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("PoveziPredmetISmer/{predmetID}/{smerID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult LinkPredmetToSmer(int predmetID, int smerID)
        {
            try
            {
                var predmet = DataProvider.VratiPredmet(predmetID);
                var smer = DataProvider.VratiSmer(smerID);
                var povezi = new UciNaView { Uci = predmet, UceNa = smer };
                DataProvider.SacuvajUciNa(povezi);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiUciNa/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteUciNa(int id)
        {
            try
            {
                DataProvider.ObrisiUciNa(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

