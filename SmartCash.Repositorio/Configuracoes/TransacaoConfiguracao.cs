using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Repositorio.Configuracoes
{
    public class TransacaoConfiguracao : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("Transacoes").HasKey(t => t.Id);
            builder.Property(nameof(Transacao.ProdutoNome)).HasColumnName("ProdutoNome").IsRequired(true).HasMaxLength(100);
            builder.Property(nameof(Transacao.Descricao)).HasColumnName("Descricao").HasMaxLength(255);
            builder.Property(nameof(Transacao.DataTransacao)).HasColumnName("DataTransacao").IsRequired(true);
            builder.Property(nameof(Transacao.Quantidade)).HasColumnName("Quantidade").IsRequired(true);
            builder.Property(nameof(Transacao.ValorUnitario)).HasColumnName("ValorUnitario").IsRequired(true);
            builder.Property(nameof(Transacao.ValorTotal)).HasColumnName("ValorTotal").IsRequired(true);
            builder.Property(nameof(Transacao.MetodoPagamento)).HasColumnName("MetodoPagamento").IsRequired(true).HasMaxLength(50);

            builder.HasOne(t => t.Usuario).WithMany(u => u.Transacoes).HasForeignKey(t => t.UsuarioId);
        }

        
    }
}