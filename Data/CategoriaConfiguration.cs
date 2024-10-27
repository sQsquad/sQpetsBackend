using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sQpets_Backend.Models;

namespace sQpets_Backend.Data
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("tb_categoria");

            builder.HasKey(x => x.IdCategoria);
            builder.Property(x => x.IdCategoria)
                .HasColumnName("idcategoria")
                .HasConversion<Guid>()
                .ValueGeneratedNever();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.Progresso)
                .HasColumnName("progresso")
                .IsRequired();
        }
    }
}