using BancoTalentos.CandidatoService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.DataAccess.Context
{
    public class DbInitializer : IDisposable
    {
        CandidatoContext _context;

        public void Dispose()
        {
            _context.Dispose();
            _context = null;

        }

        public DbInitializer(CandidatoContext context)
        {
            _context = context;
            _context.Database.Migrate();
        }

        public void Seed()
        {
            SeedStates();
            SeedDisponibilidades();
            SeedHorarios();
        }

        private void SeedDisponibilidades()
        {
            #region BR
            _context.Disponibilidade.Add(new Disponibilidade { Descricao= "Up to 4 hours per day / Até 4 horas por dia" });
            _context.Disponibilidade.Add(new Disponibilidade { Descricao = "4 to 6 hours per day / De 4 á 6 horas por dia" });

            #endregion

            _context.SaveChanges();
        }

        private void SeedHorarios()
        {
            #region BR
            _context.Horario.Add(new Horario { Descricao = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" });
            _context.Horario.Add(new Horario { Descricao = "Afternoon (from 1:00 p.m. to 6:00 p.m.) / Tarde (de 13:00 ás 18:00)" });

            #endregion

            _context.SaveChanges();
        }

        private void SeedStates()
        {
            #region BR
            _context.Estado.Add(new Estado { Codigo =  "AC", Name = "Acre" });
            _context.Estado.Add(new Estado { Codigo =  "AL", Name = "Alagoas" });
            _context.Estado.Add(new Estado { Codigo =  "AM", Name = "Amazonas" });
            _context.Estado.Add(new Estado { Codigo =  "AP", Name = "Amapá" });
            _context.Estado.Add(new Estado { Codigo =  "BA", Name = "Bahia" });
            _context.Estado.Add(new Estado { Codigo =  "CE", Name = "Ceará" });
            _context.Estado.Add(new Estado { Codigo =  "DF", Name = "Distrito Federal" });
            _context.Estado.Add(new Estado { Codigo =  "ES", Name = "Espírito Santo" });
            _context.Estado.Add(new Estado { Codigo =  "GO", Name = "Goiás" });
            _context.Estado.Add(new Estado { Codigo =  "MA", Name = "Maranhão" });
            _context.Estado.Add(new Estado { Codigo =  "MG", Name = "Minas Gerais" });
            _context.Estado.Add(new Estado { Codigo =  "MS", Name = "Mato Grosso do Sul" });
            _context.Estado.Add(new Estado { Codigo =  "MT", Name = "Mato Grosso" });
            _context.Estado.Add(new Estado { Codigo =  "PA", Name = "Pará" });
            _context.Estado.Add(new Estado { Codigo =  "PB", Name = "Paraíba" });
            _context.Estado.Add(new Estado { Codigo =  "PE", Name = "Pernambuco" });
            _context.Estado.Add(new Estado { Codigo =  "PI", Name = "Piauí" });
            _context.Estado.Add(new Estado { Codigo =  "PR", Name = "Paraná" });
            _context.Estado.Add(new Estado { Codigo =  "RJ", Name = "Rio de Janeiro" });
            _context.Estado.Add(new Estado { Codigo =  "RN", Name = "Rio Grande do Norte" });
            _context.Estado.Add(new Estado { Codigo =  "RO", Name = "Rondônia" });
            _context.Estado.Add(new Estado { Codigo =  "RR", Name = "Roraima" });
            _context.Estado.Add(new Estado { Codigo =  "RS", Name = "Rio Grande do Sul" });
            _context.Estado.Add(new Estado { Codigo =  "SC", Name = "Santa Catarina" });
            _context.Estado.Add(new Estado { Codigo =  "SE", Name = "Sergipe" });
            _context.Estado.Add(new Estado { Codigo =  "SP", Name = "São Paulo" });
            _context.Estado.Add(new Estado { Codigo =  "TO", Name = "Tocantins" });
            #endregion

            _context.SaveChanges();
        }
    }
}
