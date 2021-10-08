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
    public class NastavnoOsobljeController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveNastavnike")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNastavnici()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveNastavnike());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("PreuzmiNastavnike/{predmetID}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetNastavnik(int predmetID)
        {
            try
            {
                return new JsonResult(DataProvider.VratiNastavnikePredmeta(predmetID));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("DodajNastavnika")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNastavnik([FromBody] NastavnoOsobljeView p)
        {
            try
            {
                DataProvider.SacuvajNastavnoOsoblje(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajNastavnika/{predmetID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddNastavnikToPredmet(int predmetID, [FromBody] NastavnoOsobljeView s)
        {
            try
            {
                string id = DataProvider.SacuvajNastavnoOsoblje(s);

                var nastavnik = DataProvider.VratiNastavnoOsoblje(id);
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

        [HttpPut]
        [Route("PromeniNastavnoOsoblje")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeNastavnoOsoblje([FromBody] NastavnoOsobljeView p)
        {
            try
            {
                DataProvider.AzurirajNastavnoOsoblje(p);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiNastavnoOsoblje/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteNastavnoOsoblje(string email)
        {
            try
            {
                DataProvider.ObrisiNastavnoOsoblje(email);
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
        public IActionResult AddLogovanje([FromBody] NastavnoOsobljeView p)
        {
            try
            {
                NastavnoOsobljeView nastavnik = DataProvider.VratiNastavnoOsoblje(p.Email);
                if (nastavnik != null)
                {
                    if (nastavnik.Password == p.Password)
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
    }
}
