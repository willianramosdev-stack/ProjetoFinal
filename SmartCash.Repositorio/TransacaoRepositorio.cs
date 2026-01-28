using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartCash.Dominio.Entidades;
using SmartCash.Repositorio.Contexto;
using SmartCash.Repositorio.Interfaces;

namespace SmartCash.Repositorio
{
    public class TransacaoRepositorio : ITransacaoRepositorio
    {
        private readonly SmartCashContexto _contexto;

        public TransacaoRepositorio(SmartCashContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarAsync(Transacao transacao)
        {
            _contexto.Transacoes.Update(transacao);
            await _contexto.SaveChangesAsync();
        }

        public async Task CriarAsync(Transacao transacao)
        {
            await _contexto.Transacoes.AddAsync(transacao);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Transacao>> ListarAsync()
        {
            return await _contexto.Transacoes.ToListAsync();
        }

        public Task<Transacao> ObterPorIdAsync(int id)
        {
            return _contexto.Transacoes.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task RemoverAsync(Transacao transacao)
        {
            _contexto.Transacoes.Remove(transacao);
            await _contexto.SaveChangesAsync();
        }
    }
}