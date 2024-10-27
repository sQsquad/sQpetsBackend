using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sQpets_Backend.Models;
using sQpets_Backend.Notifications;

namespace sQpets_Backend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public ApplicationDBContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
            modelBuilder.Ignore<Notification>();
            base.OnModelCreating(modelBuilder);
        }
    }
}