using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sQpets_Backend.Models;
using sQpets_Backend.Notifications;

namespace sQpets_Backend.Validations
{
    public class CategoriaValidations : IValidate
    {
        private readonly Categoria _categoria;
        public CategoriaValidations(Categoria categoria)
        {
            _categoria = categoria;
        }

        public CategoriaValidations GuidCategoriaIsValid()
        {
            if (!Guid.TryParse(_categoria.IdCategoria, out Guid c))
                _categoria.AddNotification(new Notification("IdCategoria", "Id invalido"));
            return this;
        }

        public CategoriaValidations NomeValidation()
        {
            if (_categoria.Nome == string.Empty || _categoria.Nome.Length > 50)
                _categoria.AddNotification(new Notification("Nome", "Por favor forneça um nome valido ou menor que 50 caracteres"));
            return this;
        }

        public CategoriaValidations ProgressoValidation()
        {
            if (_categoria.Progresso < 0)
            {
                _categoria.AddNotification(new Notification("Progresso", "Por favor forneça um numero maior que zero"));
            }
            return this;
        }

        public bool IsValid()
        {
            return _categoria.Notifications.Count == 0;
        }
    }
}