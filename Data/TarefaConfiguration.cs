using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sQpets_Backend.Models;

namespace sQpets_Backend.Data
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tb_tarefa");

            builder.HasKey(x => x.IdTarefa);
            builder.Property(x => x.IdTarefa)
                .HasColumnName("idtarefa")
                .HasConversion<Guid>()
                .ValueGeneratedNever();

            builder.Property(x => x.Data)
                .HasColumnName("data")
                .IsRequired();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnName("status")
                .IsRequired();

            builder.Property(x => x.Tempo)
                .HasColumnName("tempo")
                .IsRequired();

            builder.Property(x => x.IdUsuario)
                .HasColumnName("idusuario")
                .HasConversion<Guid>()
                .IsRequired();

            builder.Property(x => x.IdCategoria)
                .HasColumnName("idcategoria")
                .HasConversion<Guid>()
                .IsRequired();
        }
    }
}