using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sQpets_Backend.Data;

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
    }
}