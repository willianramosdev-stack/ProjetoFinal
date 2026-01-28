using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Repositorio.Configuracoes
{
    public class EmpresaConfiguracao : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas").HasKey(e => e.Id);
            builder.Property(nameof(Empresa.Nome)).HasColumnName("Nome").IsRequired(true).HasMaxLength(100);
            builder.Property(nameof(Empresa.Cnpj)).HasColumnName("CNPJ").IsRequired(true).HasMaxLength(20);
        }
    }
}