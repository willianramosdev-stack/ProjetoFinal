using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Repositorio.Configuracoes
{
    public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios").HasKey(u => u.Id);
            builder.Property(nameof(Usuario.Nome)).HasColumnName("Nome").IsRequired(true).HasMaxLength(100);
            builder.Property(nameof(Usuario.Email)).HasColumnName("Email").IsRequired(true).HasMaxLength(100);
            builder.Property(nameof(Usuario.Senha)).HasColumnName("Senha").IsRequired(true).HasMaxLength(100);
            builder.Property(nameof(Usuario.Ativo)).HasColumnName("Ativo").IsRequired(true);
            builder.Property(nameof(Usuario.Salario)).HasColumnName("Salario").IsRequired(true).HasColumnType("decimal(18,2)");
        }
    }
}