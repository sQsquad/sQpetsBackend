using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Internal;
using sQpets_Backend.Data;
using sQpets_Backend.DTO;
using sQpets_Backend.Interfaces;
using sQpets_Backend.Models;

namespace sQpets_Backend.Repository
{
    public class CategoriaRepository(ApplicationDBContext context) : ICategoriaRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<ReturnDTO<Categoria>> CreateCategoria(CreateCategoriaDTO dto)
        {
            var categoria = Categoria.CreateCategoria(dto);

            if (!categoria.IsValid())
            {
                return new ReturnDTO<Categoria>(categoria.Notifications, "Por Favor Ferifique os campo", 400);
            }
            await _context.Categoria.AddAsync(categoria);
            _context.SaveChanges();

            return new ReturnDTO<Categoria>(categoria, "Categoria criada com sucesso", 201);
        }

        public async Task<ReturnDTO<List<Categoria>>> GetAllCategoriasByUser()
        {
            // if (!Guid.TryParse(idUsuario, out Guid c)) return new ReturnDTO<List<Categoria>>("Id Usuario Invalido", 400);
            var categorias = await _context.Categoria.ToListAsync();
            if (categorias.Count == 0) return new ReturnDTO<List<Categoria>>("Não existe cateogira cadastrada", 404);
            return new ReturnDTO<List<Categoria>>(categorias, "Sucesso ao recuperar os dados", 200);
        }
    }
}