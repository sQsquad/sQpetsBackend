using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sQpets_Backend.DTO
{
    public class CreateTarefaDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int Tempo { get; set; }
        public string IdUsuario { get; set; } = string.Empty;
        public string IdCategoria { get; set; } = string.Empty;
    }
}