using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using sQpets_Backend.Models;

namespace sQpets_Backend.Data
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("tb_usuario");

            builder.HasKey(x => x.IdUser);
            builder.Property(x => x.IdUser)
                .HasColumnName("iduser")
                .ValueGeneratedNever();

            builder.Property(x => x.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("email")
                .IsRequired();
            
            builder.Property(x => x.Senha)
                .HasColumnName("senha")
                .IsRequired();
        }
    }
}