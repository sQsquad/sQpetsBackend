using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sQpets_Backend.Data;

namespace sQpets_Backend.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController(ApplicationDBContext context) : ControllerBase
    {
        private readonly ApplicationDBContext _context = context;

        [HttpGet]
        public IActionResult GetAll(){
            var usuarios = _context.Usuario.ToList();
            if(usuarios == null) return BadRequest();
            return Ok(usuarios);
        }
    }
}