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
    public class EmpresaRepositorio : IEmpresaRepositorio
    {
        private readonly SmartCashContexto _contexto;

        public EmpresaRepositorio(SmartCashContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarAsync(Empresa empresa)
        {
            _contexto.Empresas.Update(empresa);
            await _contexto.SaveChangesAsync();
        }

        public async Task<bool> CnpjJaExisteAsync(string cnpj)
        {
            return await _contexto.Empresas.AnyAsync(e => e.Cnpj == cnpj);
        }

        public async Task CriarAsync(Empresa empresa)
        {
            await _contexto.Empresas.AddAsync(empresa);
            await _contexto.SaveChangesAsync();
        }

        public async Task<List<Empresa>> ListarAsync()
        {
            return await _contexto.Empresas.ToListAsync();
        }

        public async Task<Empresa> ObterPorIdAsync(int id)
        {
            return await _contexto.Empresas.FindAsync(id);
        }

        public async Task RemoverAsync(Empresa empresa)
        {
            _contexto.Empresas.Remove(empresa);
            await _contexto.SaveChangesAsync();
        }
    }
}