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
    public class PredmetController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSvePredmete")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPredmeti()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSvePredmete());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiPredmete/{smerID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetPredmet(int smerID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiPredmeteSmeraa(smerID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("DodajPredmet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPredmet([FromBody] PredmetView p)
        {
            try
            {
                DataProvider.SacuvajPredmett(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajPredmet/{smerID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddPredmetToSmer(int smerID, [FromBody] PredmetView s)
        {
            try
            {
                var id = DataProvider.SacuvajPredmett(s);

                var predmet = DataProvider.VratiPredmet(id);
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

        [HttpPut]
        [Route("PromeniPredmet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePredmet([FromBody] PredmetView p)
        {
            try
            {
                DataProvider.AzurirajPredmet(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiPredmet/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeletePredmet(int id)
        {
            try
            {
                DataProvider.ObrisiPredmet(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
