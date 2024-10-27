using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sQpets_Backend.DTO;
using sQpets_Backend.Interfaces;
using sQpets_Backend.Models;

namespace sQpets_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategorias()
        {
            var result = await _repository.GetAllCategoriasByUser();

            if (result.StatusCode == 200) return Ok(result);
            if (result.StatusCode == 400) return BadRequest(result);
            if (result.StatusCode == 404) return NotFound(result);

            return StatusCode(500, new { Message = "Erro inesperado do servidor" });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaDTO dto)
        {
            var categoria = await _repository.CreateCategoria(dto);

            if (categoria.StatusCode == 201) return Ok(categoria);
            if (categoria.StatusCode == 400) return BadRequest(categoria);

            return StatusCode(500, new { Message = "Erro inesperado do servidor" });
        }
    }
}