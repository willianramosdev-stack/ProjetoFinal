using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Dominio.Enums;

namespace SmartCash.Dominio.Entidades
{
    public class Transacao
    {
        public int Id { get; set; }
        public string ProdutoNome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTransacao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = null!;

        public decimal ValorTotal => Quantidade * ValorUnitario;

        public Transacao()
        {
            DataTransacao = DateTime.Now;
        }
    }
}
