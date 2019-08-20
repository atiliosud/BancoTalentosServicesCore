using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.ViewModel
{
    public class CandidatoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Skype { get; set; }
        public string Telefone { get; set; }
        public CidadeViewModel Cidade { get; set; }
        public string Portfolio { get; set; }
        public decimal Pretensao { get; set; }
        public List<DisponibilidadeViewModel> Disponibilidades { get; set; }
        public List<HorarioViewModel> Horarios { get; set; }
    }
}
