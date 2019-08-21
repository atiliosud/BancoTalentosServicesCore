using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoTalentos.CandidatoService.Model;
using BancoTalentos.CandidatoService.Model.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoTalentos.CandidatoService.Controllers
{
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/candidatos")]
    public class CandidatoController : ControllerBase
    {
        private ICandidatoRepository _candidatoRepository;
        public CandidatoController(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        [HttpGet()]
        [Route("List")]
        public ActionResult<List<Candidato>> Get()
        {
            try
            {
                List<Candidato> candidatos = _candidatoRepository.Get()
                       .Include(x => x.Disponibilidades)
                       .Include(x => x.Horarios)
                       .OrderByDescending(x => x.Id).ToList();
                return Ok(new BancoTalentosJson<List<Candidato>>().GetOK(candidatos));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Candidato>().GetInternalServerError(ex));
            }
        }

        [HttpGet()]
        public ActionResult<Candidato> Get([FromQuery] int? id, [FromQuery] string name)
        {
            try
            {
                IQueryable<Candidato> candidatoQuery = _candidatoRepository.Get()
                       .Include(x => x.Disponibilidades)
                       .Include(x => x.Horarios)
                       .AsNoTracking();
                if (id.HasValue)
                {
                    candidatoQuery = candidatoQuery.Where(x => x.Id == id.Value);
                }
                if (!string.IsNullOrEmpty(name))
                {
                    candidatoQuery = candidatoQuery.Where(x => x.Nome == name);
                }
                Candidato candidato = candidatoQuery.FirstOrDefault();
                return Ok(new BancoTalentosJson<Candidato>().GetOK(candidato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Candidato>().GetInternalServerError(ex));
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] Candidato candidato)
        {
            try
            {
                if (candidato == null)
                {
                    return BadRequest(new BancoTalentosJson<Candidato>().GetBadRequestNull());
                }
                _candidatoRepository.Add(candidato);
                return Ok(new BancoTalentosJson<Candidato>().GetOK(candidato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Candidato>().GetInternalServerError(ex));
            }
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Candidato candidato)
        {
            try
            {
                if (candidato == null)
                {
                    return BadRequest(new BancoTalentosJson<Candidato>().GetBadRequestNull());
                }
                _candidatoRepository.Update(candidato);
                return Ok(new BancoTalentosJson<Candidato>().GetOK(candidato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Candidato>().GetInternalServerError(ex));
            }
        }

        [HttpDelete("{id:int?}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Candidato candidato = _candidatoRepository.Get()
                       .Include(x => x.Disponibilidades)
                       .Include(x => x.Horarios)
                       .OrderByDescending(x => x.Id).ToList().FirstOrDefault(x=>x.Id==id);

                if (candidato == null)
                {
                    return BadRequest(new BancoTalentosJson<Candidato>().GetBadRequestNull());
                }
                _candidatoRepository.Delete(candidato);
                return Ok(new BancoTalentosJson<Candidato>().GetOK(candidato));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Candidato>().GetInternalServerError(ex));
            }
        }
    }
}
