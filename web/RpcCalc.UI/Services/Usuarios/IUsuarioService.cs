﻿using RpcCalc.UI.Interop.Usuarios;

namespace RpcCalc.UI.Services.Usuarios
{
    public interface IUsuarioService
    {
        Task<UsuarioDto?> Gravar(UsuarioViewModel viewModel);
        Task<UsuarioDto?> Alterar(Guid id, UsuarioViewModel viewModel);
        Task<string> AlterarStatus(Guid id, UsuarioInativacaoViewModel viewModel);
        Task<UsuarioDto?> Capturar(Guid id);
        Task<IEnumerable<UsuarioDto>?> ObterTodos();
        Task<bool> ExcluirUsuarioPerfil(Guid idusuario, Guid idperfil, Guid idpermissao);
        Task<UsuarioDto?> ObterPorEmail(EmailViewModel viewModel);
    }
}
