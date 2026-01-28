using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Aplicacao.Interfaces
{
    public interface ITransacaoAplicacao
    {
        Task<Transacao> ObterPorIdAsync(int id);

        Task<List<Transacao>> ListarAsync();

        Task CriarAsync(Transacao transacao);

        Task RemoverAsync(Transacao transacao);
    }
}