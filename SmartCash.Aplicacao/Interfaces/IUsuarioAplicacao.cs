using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Aplicacao.Interfaces
{
    public interface IUsuarioAplicacao
    {
        Task CriarUsuarioasync(Usuario usuario);
        Task<Usuario> ObterUsuarioPorEmailAsync(string email);
        Task<List<Usuario>> ObterTodosUsuariosAsync();
        Task AtualizarSenhaAsync(string Email, string novaSenha);
        Task DesativarUsuarioAsync(string email);
    }
}