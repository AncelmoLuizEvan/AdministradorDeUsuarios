﻿using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;
using SecureIdentity.Password;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioSearch : IUsuarioSearch
    {
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepositoryReadOnly _repositoryUsuarioPerfilReadOnly;

        public UsuarioSearch(IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepositoryReadOnly repositoryUsuarioPerfilReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
            _repositoryUsuarioPerfilReadOnly = repositoryUsuarioPerfilReadOnly;
        }

        public async Task<UsuarioDto?> Capturar(Guid id)
        {
            var result = await _repositoryReadOnly.Capturar(id);
            if (result is null)
                return null;

            var usuario = result.EntityForDto();
            var usuarioPerfil = await _repositoryUsuarioPerfilReadOnly.CapiturarPorUsuario(usuario.Id);

            var entityForDtoList = usuarioPerfil.EntityForDtoList();
            usuario.UsuarioPerfis = entityForDtoList.ToList();

            return usuario;
        }

        public async Task<IEnumerable<UsuarioDto>?> Listar()
        {
            var result = await _repositoryReadOnly.Listar();

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return Enumerable.Empty<UsuarioDto>();
        }

        public async Task<LoginDto?> ValidarLogin(string email, string senha)
        {
            var result = await _repositoryReadOnly.ObterPorLogin(email);

            if (result == null)
                return null;

            if (!PasswordHasher.Verify(result.Senha, senha))
                return null;

            if (result is not null)
                return result.EntityForLoginDto();

            return null;

        }

        public async Task<UsuarioDto?> ObterPorEmail(string email)
        {
            var result = await _repositoryReadOnly.ObterPorLogin(email);
            if (result is null)
                return null;

            var usuario = result.EntityForDto();
            var usuarioPerfil = await _repositoryUsuarioPerfilReadOnly.CapiturarPorUsuario(usuario.Id);

            var entityForDtoList = usuarioPerfil.EntityForDtoList();
            usuario.UsuarioPerfis = entityForDtoList.ToList();

            return usuario;

        }
    }
}
