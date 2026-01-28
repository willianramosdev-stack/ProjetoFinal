using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Aplicacao.Interfaces;
using SmartCash.Dominio.Entidades;
using SmartCash.Repositorio.Interfaces;

namespace SmartCash.Aplicacao
{
    public class TransacaoAplicacao : ITransacaoAplicacao
    {
        private readonly ITransacaoRepositorio _transacaoRepositorio;

        public TransacaoAplicacao(ITransacaoRepositorio transacaoRepositorio)
        {
            _transacaoRepositorio = transacaoRepositorio;
        }

        public async Task CriarAsync(Transacao transacao)
        {
            if (transacao == null){
                throw new Exception("Transação inválida.");
            }
            if (transacao.ValorUnitario <= 0){
                throw new Exception("O valor da transação deve ser maior que zero.");
            }
            await _transacaoRepositorio.CriarAsync(transacao);
        }

        public async Task<List<Transacao>> ListarAsync()
        {
            return await _transacaoRepositorio.ListarAsync();
        }

        public async Task<Transacao> ObterPorIdAsync(int id)
        {
            return await _transacaoRepositorio.ObterPorIdAsync(id);
        }

        public async Task RemoverAsync(Transacao transacao)
        {
            var transacaoExistente = await _transacaoRepositorio.ObterPorIdAsync(transacao.Id);
            if (transacaoExistente == null)
            {
                throw new Exception("Transação não encontrada.");
            }
            await _transacaoRepositorio.RemoverAsync(transacaoExistente);
        }
    }
}