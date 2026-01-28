using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Aplicacao.Interfaces;
using SmartCash.Dominio.Entidades;
using SmartCash.Repositorio.Interfaces;

namespace SmartCash.Aplicacao
{
    public class UsuarioAplicacao : IUsuarioAplicacao
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioAplicacao(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task AtualizarSenhaAsync(string Email, string novaSenha)
        {
            var usuario = await _usuarioRepositorio.ObterUsuarioPorEmailAsync(Email);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            if (!usuario.Ativo)
            {
                throw new Exception("Usuário está desativado.");
            }
            usuario.Senha = novaSenha;
            await  _usuarioRepositorio.AtualizarSenhaAsync(usuario);
        }

        public async Task CriarUsuarioasync(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("Usuário inválido.");
            }
            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Senha))
            {
                throw new Exception("Email e senha são obrigatórios.");
            }
            await _usuarioRepositorio.CriarUsuarioasync(usuario);
        }

        public async Task DesativarUsuarioAsync(string email)
        {
            var usuario = await _usuarioRepositorio.ObterUsuarioPorEmailAsync(email);
            if (usuario == null)
            {
                throw new Exception("Usuário não encontrado.");
            }
            usuario.Ativo = false;
            await _usuarioRepositorio.DesativarUsuarioAsync(usuario);
        }

        public async Task<List<Usuario>> ObterTodosUsuariosAsync()
        {
            return await _usuarioRepositorio.ObterTodosUsuariosAsync();
        }

        public async Task<Usuario> ObterUsuarioPorEmailAsync(string email)
        {
            return await _usuarioRepositorio.ObterUsuarioPorEmailAsync(email);
        }
    }
}