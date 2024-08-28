using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sQpets_Backend.DTO
{
    public class EditTarefaDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int Tempo { get; set; }
    }
}