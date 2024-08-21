using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using sQpets_Backend.DTO;

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

        public static class Factories
        {
            public static Tarefa CreateTarefa(CreateTarefaDTO dto)
            {
                if(dto.Nome == string.Empty) throw new Exception("Nome não pode estar vazio");
                if(dto.Tempo < 0) throw new Exception("O campo tempo não pode ser negativo");

                return new Tarefa()
                {
                    IdTarefa = Guid.NewGuid(),
                    Data = DateTime.UtcNow,
                    Nome = dto.Nome,
                    Status = false,
                    Tempo = dto.Tempo,
                    IdUsuario = dto.IdUsuario,
                    IdCategoria = dto.IdCategoria
                };
            }
        }
    }
}