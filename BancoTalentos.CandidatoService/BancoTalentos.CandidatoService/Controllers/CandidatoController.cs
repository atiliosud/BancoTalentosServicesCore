using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BancoTalentos.CandidatoService.Model;
using BancoTalentos.CandidatoService.Model.Repository;
using BancoTalentos.CandidatoService.ViewModel;
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
        
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet()]
        public ActionResult<CandidatoViewModel> Get([FromQuery] int? id, [FromQuery] string name)
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
                //CandidatoViewModel candidato = billsQuery.OrderByDescending(x => x.BillDate).ToList();
                //return Ok(new EnernocJson<List<Bill>>().GetOK(bills));
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
