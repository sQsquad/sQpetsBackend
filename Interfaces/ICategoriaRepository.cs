using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sQpets_Backend.DTO;
using sQpets_Backend.Models;

namespace sQpets_Backend.Interfaces
{
    public interface ICategoriaRepository
    {
        public Task<ReturnDTO<List<Categoria>>> GetAllCategoriasByUser();
        public Task<ReturnDTO<Categoria>> CreateCategoria(CreateCategoriaDTO dto);
    }
}