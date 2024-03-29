﻿using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.AuthenticationUseCase;
using RpcCalc.Domain.Interop.Authentication;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;
using SecureIdentity.Password;

namespace RpcCalc.UseCases.AuthenticaionUseCases
{
    public class NovaContaCreate : INovaContaCreate
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepository _repositoryUsuarioPerfil;
        private readonly IUsuarioRoleRepository _usuarioRoleRepository;
        private readonly IPerfilRepositoryReadOnly _perfilRepositoryReadOnly;
        private readonly IRoleRepositoryReadOnly _roleRepositoryReadOnly;
        private readonly IPermissaoRepositoryReadOnly _permissaoRepositoryReadOnly;

        public NovaContaCreate(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepository repositoryUsuarioPerfil,
            IUsuarioRoleRepository usuarioRoleRepository,
            IPerfilRepositoryReadOnly perfilRepositoryReadOnly,
            IRoleRepositoryReadOnly roleRepositoryReadOnly,
            IPermissaoRepositoryReadOnly permissaoRepositoryReadOnly)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _repositoryUsuarioPerfil = repositoryUsuarioPerfil;
            _usuarioRoleRepository = usuarioRoleRepository;
            _perfilRepositoryReadOnly = perfilRepositoryReadOnly;
            _roleRepositoryReadOnly = roleRepositoryReadOnly;
            _permissaoRepositoryReadOnly = permissaoRepositoryReadOnly;
        }

        public async Task<NovaContaDto> Execute(NovaContaViewModel viewModel)
        {
            try
            {
                var emailJaCadastrado = await _repositoryReadOnly.ObterPorLogin(viewModel.Email);

                if (emailJaCadastrado is not null)
                    return null;

                _unitOfWork.BeginTransaction();

                var senha = viewModel.CnpjCpf.Replace(".", "").Replace("-", "");
                viewModel.Login = viewModel.Email.Replace("@", "-").Replace(".", "-");

                var entity = viewModel.NovaContaViewModelForEntity(PasswordHasher.Hash(senha));

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                var perfis = await _perfilRepositoryReadOnly.Listar();
                var perfilVitalicio = perfis.FirstOrDefault(x => x.Nome.Equals("Vitalicio"));

                var permissao = await _permissaoRepositoryReadOnly.Listar();
                var permissaoRpcWeb = permissao.FirstOrDefault(x => x.Sistema.Equals("RPC Web Admin"));

                var usuarioPerfilDto = new UsuarioPerfilDto
                {
                    UsuarioId = result!.Id,
                    PerfilId = perfilVitalicio!.Id,
                    Perfil = perfilVitalicio.Nome!,
                    PermissaoId = permissaoRpcWeb!.Id,
                    Permissao = permissaoRpcWeb.Sistema
                };

                var usuarioPerfilEntity = usuarioPerfilDto.DtoForEntity(usuarioPerfilDto.Perfil);

                await _repositoryUsuarioPerfil.Gravar(usuarioPerfilEntity);

                var roles = await _roleRepositoryReadOnly.Listar();

                var roleCliente = (viewModel.Email.Equals("admin@admin.com")) ? roles.FirstOrDefault(x => x.Nome.Equals("Admin")) : roles.FirstOrDefault(x => x.Nome.Equals("Cliente"));

                var usuarioRoleDto = new UsuarioRoleDto { UsuarioId = result!.Id, RoleId = roleCliente.Id, };
                var usuarioRoleEntity = usuarioRoleDto.DtoForEntity();
                await _usuarioRoleRepository.Gravar(usuarioRoleEntity);

                _unitOfWork.Commit();

                if (result is not null)
                    return result.NovaContaEntityForDto();

                return new NovaContaDto();
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                _unitOfWork.Rollback();
                throw;
            }

        }
    }
}
