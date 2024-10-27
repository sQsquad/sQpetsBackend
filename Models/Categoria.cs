using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sQpets_Backend.DTO;
using sQpets_Backend.Validations;

namespace sQpets_Backend.Models
{
    public class Categoria : BaseEntity, IValidate
    {
        public string IdCategoria { get; set; } = string.Empty;
        public string Nome { get; set; } = string.Empty;
        public int Progresso { get; set; }

        public static Categoria CreateCategoria(CreateCategoriaDTO dto)
        {
            return new Categoria()
            {
                IdCategoria = Guid.NewGuid().ToString(),
                Nome = dto.Nome,
                Progresso = dto.Progresso
            };
        }
        public bool IsValid()
        {
            return new CategoriaValidations(this)
            .GuidCategoriaIsValid()
            .NomeValidation()
            .ProgressoValidation()
            .IsValid();
        }
    }
}