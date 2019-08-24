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
    [Route("api/v{version:apiVersion}/Horarios")]
    public class HorarioController : ControllerBase
    {
        private IHorarioRepository _HorarioRepository;
        public HorarioController(IHorarioRepository HorarioRepository)
        {
            _HorarioRepository = HorarioRepository;
        }

        [HttpGet()]
        [Route("List")]
        public ActionResult<List<Horario>> Get()
        {
            try
            {
                List<Horario> Horarios = _HorarioRepository.Get()
                       .Include(x => x.Horarios)
                       .OrderByDescending(x => x.Descricao).ToList();
                return Ok(new BancoTalentosJson<List<Horario>>().GetOK(Horarios));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Horario>().GetInternalServerError(ex));
            }
        }

        [HttpGet()]
        public ActionResult<Horario> Get([FromQuery] int? candidatoId)
        {
            try
            {
                IQueryable<Horario> HorarioQuery = _HorarioRepository.Get()
                       .Include(x => x.Horarios)
                       .AsNoTracking();
                if (candidatoId.HasValue)
                {
                    HorarioQuery = HorarioQuery.Where(x => x.Horarios.Any(b=>b.Candidato.Id == candidatoId));
                }
                Horario Horario = HorarioQuery.FirstOrDefault();
                return Ok(new BancoTalentosJson<Horario>().GetOK(Horario));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new BancoTalentosJson<Horario>().GetInternalServerError(ex));
            }
        }
    }
}
