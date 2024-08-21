using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sQpets_Backend.Data;
using sQpets_Backend.DTO;
using sQpets_Backend.Models;

namespace sQpets_Backend.Controllers
{
    [ApiController]
    [Route("api/tarefa")]
    public class TarefaController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public IActionResult GetAll()
        {
            var tarefas = _context.Tarefa.ToList();
            if(tarefas == null) return BadRequest();
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody]CreateTarefaDTO dto)
        {
            var tarefa = Tarefa.Factories.CreateTarefa(dto);
            _context.Add(tarefa);
            _context.SaveChanges();
            return Ok(tarefa);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody]DeleteTarefaDTO dto) 
        {
            var tarefa = _context.Tarefa.Where(x => x.IdTarefa == dto.IdTarefa).FirstOrDefault();
            if(tarefa == null) return NotFound();
            _context.Tarefa.Remove(tarefa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}