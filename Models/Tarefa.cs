using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sQpets_Backend.Models
{
    public class Tarefa
    {
        public Guid IdTarefa {get; set;}
        public DateTime Data { get; set; }
        public string Nome { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int Tempo { get; set; }
        public Guid IdUsuario { get; set; }
        public Guid IdCategoria { get; set; }
    }
}