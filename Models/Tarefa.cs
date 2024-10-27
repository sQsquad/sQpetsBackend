using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using sQpets_Backend.DTO;
using sQpets_Backend.Validations;

namespace sQpets_Backend.Models
{
    public class Tarefa : BaseEntity, IValidate
    {
        public string IdTarefa { get; private set; } = string.Empty;
        public DateTime Data { get; private set; }
        public string Nome { get; private set; } = string.Empty;
        public bool Status { get; private set; }
        public int Tempo { get; private set; }
        public string IdUsuario { get; private set; } = string.Empty;
        public string IdCategoria { get; private set; } = string.Empty;
        public static Tarefa CreateTarefa(CreateTarefaDTO dto)
        {
            return new Tarefa()
            {
                IdTarefa = Guid.NewGuid().ToString(),
                Data = DateTime.UtcNow,
                Nome = dto.Nome,
                Status = false,
                Tempo = dto.Tempo,
                IdUsuario = dto.IdUsuario,
                IdCategoria = dto.IdCategoria
            };
        }

        public void EditTarefa(EditTarefaDTO dto)
        {
            Nome = dto.Nome;
            Tempo = dto.Tempo;
        }

        public bool IsValid()
        {
            return new TarefaValdations(this)
                .GuidUsuarioIsValid()
                .GuidCategoriaIsValid()
                .NomeValidation()
                .IsValid();
        }
    }
}