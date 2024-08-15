using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sQpets_Backend.Models;

namespace sQpets_Backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions)
        {
            
        }

        public DbSet<Usuario> Usuario {get; set;}
    }
}