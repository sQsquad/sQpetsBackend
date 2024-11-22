using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sQpets_Backend.Models;
using sQpets_Backend.Notifications;

namespace sQpets_Backend.Validations
{
    public class TarefaValdations : IValidate
    {
        private readonly Tarefa _tarefa;
        public TarefaValdations(Tarefa tarefa)
        {
            _tarefa = tarefa;
        }

        public TarefaValdations GuidCategoriaIsValid()
        {
            if(!Guid.TryParse(_tarefa.Categoria, out Guid c))
                _tarefa.AddNotification(new Notification("IdCategoria", "Id invalido"));
            return this;
        }
         public TarefaValdations GuidUsuarioIsValid()
        {
            if(!Guid.TryParse(_tarefa.IdUsuario, out Guid u))
                _tarefa.AddNotification(new Notification("IdUsuario", "Id invalido"));
            return this;
        }
        
        public TarefaValdations NomeValidation()
        {
            if(_tarefa.Nome == string.Empty || _tarefa.Nome.Length > 50)
                _tarefa.AddNotification(new Notification("Nome", "Por favor forneça um nome valido ou menor que 50 caracteres"));
            return this;
        }

        public bool IsValid()
        {
            return _tarefa.Notifications.Count == 0;
        }
    }
}