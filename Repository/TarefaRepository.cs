using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sQpets_Backend.Data;
using sQpets_Backend.DTO;
using sQpets_Backend.Interfaces;
using sQpets_Backend.Models;
using sQpets_Backend.Notifications;

namespace sQpets_Backend.Repository
{
    public class TarefaRepository(ApplicationDBContext context) : ITarefaRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<ReturnDTO<List<Tarefa>>> GetAllTarefasByUser(string idUser)
        {
            if (!Guid.TryParse(idUser, out Guid c)) return new ReturnDTO<List<Tarefa>>("Id Usuario Invalido", 400);
            var tarefa = await _context.Tarefa.Where(x => x.IdUsuario == idUser).ToListAsync();
            List<Tarefa> tarefas = new List<Tarefa>();
            foreach (var tarefa1 in tarefa)
            {
                var categ = await _context.Categoria.FirstOrDefaultAsync(x => x.IdCategoria == tarefa1.Categoria);
                tarefa1.Categoria = categ.Nome;
                tarefas.Add(tarefa1);
            }
            if (tarefa.Count == 0) return new ReturnDTO<List<Tarefa>>("Não existe tarefa para esse usuario", 404);
            return new ReturnDTO<List<Tarefa>>(tarefas, "Sucesso ao recuperar os dados", 200);
        }

        public async Task<ReturnDTO<Tarefa>> CreateTarefa(CreateTarefaDTO dto)
        {
            var tarefa = Tarefa.CreateTarefa(dto);

            if (!tarefa.IsValid())
            {
                return new ReturnDTO<Tarefa>(tarefa.Notifications, "Por Favor Verifique os Campos", 400);
            }
            await _context.AddAsync(tarefa);
            _context.SaveChanges();

            return new ReturnDTO<Tarefa>(tarefa, "Tarefa Criada Com Sucesso", 200);
        }

        public async Task<ReturnDTO<Tarefa>> DeleteTarefa(string id)
        {
            var tarefa = await _context.Tarefa.Where(x => x.IdTarefa == id).FirstOrDefaultAsync();
            if (tarefa == null) return new ReturnDTO<Tarefa>("Id Invalido", 404);

            _context.Tarefa.Remove(tarefa);
            _context.SaveChanges();
            return new ReturnDTO<Tarefa>("Deletada com sucesso", 204);


        }

        public async Task<ReturnDTO<Tarefa>> EditTarefa(string id, EditTarefaDTO dto)
        {
            var tarefa = await _context.Tarefa.Where(x => x.IdTarefa == id).FirstOrDefaultAsync();
            if (tarefa == null)
                return new ReturnDTO<Tarefa>("Id Invalido", 404);
            tarefa.EditTarefa(dto);
            _context.SaveChanges();
            return new ReturnDTO<Tarefa>(tarefa, "Tarefa Editada Com Sucesso", 200);
        }
    }
}