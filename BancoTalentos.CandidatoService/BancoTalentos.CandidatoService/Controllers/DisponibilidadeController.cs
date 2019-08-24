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
    [Route("api/v{version:apiVersion}/Disponibilidades")]
    public class DisponibilidadeController : ControllerBase
    {
        private IDisponibilidadeRepository _DisponibilidadeRepository;
        public DisponibilidadeController(IDisponibilidadeRepository DisponibilidadeRepository)
        {
            _DisponibilidadeRepository = DisponibilidadeRepository;
        }

        [HttpGet()]
        [Route("List")]
        public ActionResult<List<Disponibilidade>> Get()
        {
            try
            {
                List<Disponibilidade> Disponibilidades = _DisponibilidadeRepository.Get()
                       .Include(x => x.Disponibilidades)
                       .OrderByDescending(x => x.Descricao).ToList();
                return Ok(new BancoTalentosJson<List<Disponibilidade>>().GetOK(Disponibilidades));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Disponibilidade>().GetInternalServerError(ex));
            }
        }

        [HttpGet()]
        public ActionResult<Disponibilidade> Get([FromQuery] int? candidatoId)
        {
            try
            {
                IQueryable<Disponibilidade> DisponibilidadeQuery = _DisponibilidadeRepository.Get()
                       .Include(x => x.Disponibilidades)
                       .AsNoTracking();
                if (candidatoId.HasValue)
                {
                    DisponibilidadeQuery = DisponibilidadeQuery.Where(x => x.Disponibilidades.Any(b=>b.Candidato.Id == candidatoId));
                }
                Disponibilidade Disponibilidade = DisponibilidadeQuery.FirstOrDefault();
                return Ok(new BancoTalentosJson<Disponibilidade>().GetOK(Disponibilidade));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Disponibilidade>().GetInternalServerError(ex));
            }
        }
    }
}
