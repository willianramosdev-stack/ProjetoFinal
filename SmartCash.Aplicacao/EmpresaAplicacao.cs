using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Aplicacao.Interfaces;
using SmartCash.Dominio.Entidades;
using SmartCash.Repositorio.Interfaces;

namespace SmartCash.Aplicacao
{
    public class EmpresaAplicacao : IEmpresaAplicacao
    {
        private readonly IEmpresaRepositorio _empresaRepositorio;

        public EmpresaAplicacao(IEmpresaRepositorio empresaRepositorio)
        {
            _empresaRepositorio = empresaRepositorio;
        }

        public async Task AtualizarAsync(Empresa empresa)
        {
            var empresaExistente = await _empresaRepositorio.ObterPorIdAsync(empresa.Id);
            if (empresaExistente == null)
            {
                throw new Exception("Empresa não encontrada.");
            }
            empresaExistente.Nome = empresa.Nome;
            empresaExistente.Cnpj = empresa.Cnpj;
            await _empresaRepositorio.AtualizarAsync(empresaExistente);
        }

        public async Task<bool> CnpjJaExisteAsync(string cnpj)
        {
            if (string.IsNullOrEmpty(cnpj))
            {
                throw new Exception("CNPJ inválido.");
            }
            return await _empresaRepositorio.CnpjJaExisteAsync(cnpj);
        }

        public async Task CriarAsync(Empresa empresa)
        {
            if (empresa == null)
            {
                throw new Exception("Empresa inválida.");
            }
            if (string.IsNullOrEmpty(empresa.Nome) || string.IsNullOrEmpty(empresa.Cnpj))
            {
                throw new Exception("Nome e CNPJ são obrigatórios.");
            }
            await _empresaRepositorio.CriarAsync(empresa);
        }

        public async Task<List<Empresa>> ListarAsync()
        {
            return await _empresaRepositorio.ListarAsync();
        }

        public async Task<Empresa> ObterPorIdAsync(int id)
        {
            return await _empresaRepositorio.ObterPorIdAsync(id);
        }

    }
}