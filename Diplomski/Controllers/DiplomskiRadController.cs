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
    public class DiplomskiRadController : ControllerBase
    {
        [HttpGet]
        [Route("PreuzmiSveDiplomske")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDiplomski()
        {
            try
            {
                return new JsonResult(DataProvider.VratiSveDiplomskeRadove());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpGet]
        [Route("PreuzmiDiplomskeRadove/{idPredmeta}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetDiplomskiRadovi(int idPredmeta)
        {
            try
            {
                return new JsonResult(DataProvider.VratiDiplomskiRadPredmet(idPredmeta));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDiplomskiRad/{IdPredmeta}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddDiplomskiWithPredmet([FromRoute(Name = "idPredmeta")] string idPredmeta, [FromBody] DiplomskiRadView o)
        {
            try
            {
                var predmet = DataProvider.VratiPredmet(Int32.Parse(idPredmeta));
                o.UpisaoPredmet = predmet;
               // DataProvider.DodajDiplomskiRad(o);

                var student = DataProvider.VratiStudenta(o.EmailStudd);
                o.UpisaoStudent = student; 
                
                var nastavnik = DataProvider.VratiNastavnoOsoblje(o.EmailNass);
                o.Mentor = nastavnik; 

                DataProvider.DodajDiplomskiRad(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("DodajDiplomskiRad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult AddDiplomski([FromBody] DiplomskiRadView o)
        {
            try
            {
                var predmet = DataProvider.VratiPredmet( Int32.Parse(o.IdPredmetaa));
                o.UpisaoPredmet = predmet;
                // DataProvider.DodajDiplomskiRad(o);

                var student = DataProvider.VratiStudenta(o.EmailStudd);
                o.UpisaoStudent = student;

                var nastavnik = DataProvider.VratiNastavnoOsoblje(o.EmailNass);
                o.Mentor = nastavnik;

                DataProvider.DodajDiplomskiRad(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("PromeniDiplomskiRad")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangeDiplomskiRad([FromBody] DiplomskiRadView o)
        {
            try
            {
                DataProvider.UpdateDiplomskiRad(o);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpDelete]
        [Route("IzbrisiDiplomskiRad/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                DataProvider.ObrisiDiplomskiRad(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

    }
}
