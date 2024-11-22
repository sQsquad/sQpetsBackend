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
using sQpets_Backend.Repository;

namespace sQpets_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _repository;

        public TarefaController(ITarefaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetAllByUser([FromRoute] string idUser)
        {
            var result = await _repository.GetAllTarefasByUser(idUser);

            if (result.StatusCode == 200) return Ok(result);
            if (result.StatusCode == 400) return BadRequest(result);
            if (result.StatusCode == 404) return NotFound(result);

            return StatusCode(500, new { Message = "Erro inesperado do servidor" });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTarefaDTO dto)
        {
            var tarefa = await _repository.CreateTarefa(dto);

            if (tarefa.StatusCode == 200) return Ok(tarefa);
            if (tarefa.StatusCode == 400) return BadRequest(tarefa);

            return StatusCode(500, new { Message = "Erro inesperado do servidor" });
        }

        [HttpDelete("{idTarefa}")]
        public async Task<IActionResult> Delete([FromRoute] string idTarefa)
        {
            var tarefa = await _repository.DeleteTarefa(idTarefa);

            if (tarefa.StatusCode == 204) return NoContent();
            if (tarefa.StatusCode == 404) return NotFound();

            return StatusCode(500, new { Message = "Erro inesperado do servidor" });
        }

        [HttpPut("{idTarefa}")]
        public async Task<IActionResult> Edit([FromRoute] string idTarefa, [FromBody] EditTarefaDTO dto)
        {
            var tarefa = await _repository.EditTarefa(idTarefa, dto);

            if (tarefa.StatusCode == 404) return NotFound();
            if (tarefa.StatusCode == 200) return Ok(tarefa);

            return StatusCode(500, new { Message = "Erro inesperado do servidor" });
        }
    }
}