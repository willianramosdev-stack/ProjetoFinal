using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Repositorio.Interfaces
{
    public interface ITransacaoRepositorio
    {
        Task<Transacao> ObterPorIdAsync(int id);

        Task<List<Transacao>> ListarAsync();

        Task CriarAsync(Transacao transacao);

        Task AtualizarAsync(Transacao transacao);

        Task RemoverAsync(Transacao transacao);
    }
}