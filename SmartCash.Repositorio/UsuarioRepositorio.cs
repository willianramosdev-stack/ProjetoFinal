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
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SmartCashContexto _contexto;

        public UsuarioRepositorio(SmartCashContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task AtualizarSenhaAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task CriarUsuarioasync(Usuario usuario)
        {
            await _contexto.Usuarios.AddAsync(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task DesativarUsuarioAsync(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            await _contexto.SaveChangesAsync();
        }

        public async Task<decimal> ObterSalarioUsuarioAsync(int usuarioId)
        {
            return await _contexto.Usuarios.Where(u => u.Id == usuarioId).Select(u => u.Salario).FirstOrDefaultAsync();
        }

        public async Task<List<Usuario>> ObterTodosUsuariosAsync()
        {
            return await _contexto.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
        {
            return await _contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}