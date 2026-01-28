using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartCash.Dominio.Entidades;

namespace SmartCash.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task CriarUsuarioasync(Usuario usuario);
        Task<Usuario> ObterUsuarioPorEmailAsync(string email);
        Task<List<Usuario>> ObterTodosUsuariosAsync();
        Task AtualizarSenhaAsync(Usuario usuario);
        Task DesativarUsuarioAsync(Usuario usuario);

    }
}