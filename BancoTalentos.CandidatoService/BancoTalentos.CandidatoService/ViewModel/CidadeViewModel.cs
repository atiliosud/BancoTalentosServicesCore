using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.ViewModel
{
    public class CidadeViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public EstadoViewModel Estado { get; set; }
    }
}
