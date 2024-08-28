using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sQpets_Backend.DTO;
using sQpets_Backend.Models;
using sQpets_Backend.Notifications;

namespace sQpets_Backend.Interfaces
{
    public interface ITarefaRepository
    {
        public Task<ReturnDTO<List<Tarefa>>> GetAllTarefasByUser(string idUser);
        public Task<ReturnDTO<Tarefa>> CreateTarefa(CreateTarefaDTO dto);
        public Task<ReturnDTO<Tarefa>> EditTarefa(string id,EditTarefaDTO dto);
        public Task<ReturnDTO<Tarefa>> DeleteTarefa(string id);
    }
}