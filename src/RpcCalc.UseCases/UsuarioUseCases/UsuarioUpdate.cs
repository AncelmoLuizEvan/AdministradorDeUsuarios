using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioUpdate : IUsuarioUpdate
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepository _repositoryUsuarioPerfil;
        private readonly IUsuarioRoleRepository _repositoryUsuarioRole;
        private readonly IUsuarioRoleRepositoryReadOnly _repositoryReadOnlyUsuarioRole;
        private readonly IUsuarioPerfilRepositoryReadOnly _repositoryReadOnlyUsuarioPerfil;

        public UsuarioUpdate(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepository usuarioPerfilRepository,
            IUsuarioRoleRepository usuarioRoleRepository,
            IUsuarioRoleRepositoryReadOnly usuarioRoleRepositoryReadOnly,
            IUsuarioPerfilRepositoryReadOnly usuarioPerfilRepositoryReadOnly)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _repositoryUsuarioPerfil = usuarioPerfilRepository;
            _repositoryUsuarioRole = usuarioRoleRepository;
            _repositoryReadOnlyUsuarioRole = usuarioRoleRepositoryReadOnly;
            _repositoryReadOnlyUsuarioPerfil = usuarioPerfilRepositoryReadOnly;
        }

        public async Task<UsuarioDto> Execute(Guid id, UsuarioViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                viewModel.Login = viewModel.Email.Replace("@", "-").Replace(".", "-");

                var usuario = await _repositoryReadOnly.Capturar(id);

                usuario!.AtualizarDados(viewModel.CnpjCpf, viewModel.Nome, viewModel.Login, viewModel.Email, viewModel.Celular);

                await _repository.Alterar(usuario);

                if (viewModel.UsuarioPerfis.Count < usuario.UsuarioPerfis.Count)
                {
                    foreach (var item in usuario.UsuarioPerfis)
                    {
                        var naoExcluir = viewModel.UsuarioPerfis.Any(x => x.UsuarioId == item.UsuarioId
                                                                    && x.PerfilId == item.PerfilId
                                                                    && x.PermissaoId == item.PermissaoId);

                        if (naoExcluir)
                            continue;

                        var result = await _repositoryReadOnlyUsuarioPerfil.CapiturarPermissaoDoUsuario(item.UsuarioId, item.PerfilId, item.PermissaoId);

                        if (result is not null)
                            await _repositoryUsuarioPerfil.Excluir(result);
                    }
                }

                foreach (var usuarioPerfil in viewModel.UsuarioPerfis)
                {
                    usuarioPerfil.UsuarioId = usuario!.Id;

                    var jaCadastrado = usuario.UsuarioPerfis.Any(x => x.UsuarioId == usuarioPerfil.UsuarioId
                                                                    && x.PerfilId == usuarioPerfil.PerfilId
                                                                    && x.PermissaoId == usuarioPerfil.PermissaoId);

                    if (jaCadastrado)
                        continue;

                    var usuarioPerfilEntity = usuarioPerfil.DtoForEntity(usuarioPerfil.Perfil);
                    await _repositoryUsuarioPerfil.Gravar(usuarioPerfilEntity);
                }

                if (viewModel.Roles.Count < usuario.Roles.Count)
                {
                    foreach (var item in usuario.Roles)
                    {
                        var naoExcluir = viewModel.Roles.Any(x => x.UsuarioId == item.UsuarioId
                                                                && x.RoleId == item.RoleId);

                        if (naoExcluir)
                            continue;

                        var result = await _repositoryReadOnlyUsuarioRole.CapiturarRoleDoUsuario(item.UsuarioId, item.RoleId);

                        if (result is not null)
                            await _repositoryUsuarioRole.Excluir(result);
                    }
                }

                foreach (var role in viewModel.Roles)
                {
                    var usuarioRole = new UsuarioRoleDto
                    {
                        UsuarioId = usuario!.Id,
                        RoleId = role.RoleId,
                        Role = role.Role
                    };

                    var jaCadastrado = usuario.Roles.Any(x => x.UsuarioId == role.UsuarioId
                                                            && x.RoleId == role.RoleId);

                    if (jaCadastrado)
                        continue;

                    var usuarioRoleEntity = usuarioRole.DtoForEntity();
                    await _repositoryUsuarioRole.Gravar(usuarioRoleEntity);
                }

                _unitOfWork.Commit();

                return usuario.EntityForDto();
            }
            catch (Exception ex)
            {
                var logErro = ex.Message;
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
