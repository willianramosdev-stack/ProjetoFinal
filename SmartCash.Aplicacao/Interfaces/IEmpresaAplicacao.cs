using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Aplicacao.Interfaces
{
    public interface IEmpresaAplicacao
    {
        Task<Empresa> ObterPorIdAsync(int id);

        Task<List<Empresa>> ListarAsync();

        Task CriarAsync(Empresa empresa);

        Task AtualizarAsync(Empresa empresa);

        Task<bool> CnpjJaExisteAsync(string cnpj);
    }
}