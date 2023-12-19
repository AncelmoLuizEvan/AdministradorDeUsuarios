using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;
using SecureIdentity.Password;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioCreate : IUsuarioCreate
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepository _repositoryUsuarioPerfil;
        private readonly IUsuarioRoleRepository _usuarioRoleRepository;

        public UsuarioCreate(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly,
            IUsuarioPerfilRepository repositoryUsuarioPerfil,
            IUsuarioRoleRepository usuarioRoleRepository
           )
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = usuarioRepositoryReadOnly;
            _repositoryUsuarioPerfil = repositoryUsuarioPerfil;
            _usuarioRoleRepository = usuarioRoleRepository;
        }

        public async Task<UsuarioDto> Execute(UsuarioViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var senha = viewModel.CnpjCpf.Replace(".", "").Replace("-", "");
                var entity = viewModel.ViewModelForEntity(PasswordHasher.Hash(senha));

                viewModel.Login = viewModel.Email.Replace("@", "-").Replace(".", "-");

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                foreach (var usuarioPerfil in viewModel.UsuarioPerfis)
                {
                    usuarioPerfil.UsuarioId = result!.Id;

                    var usuarioPerfilEntity = usuarioPerfil.DtoForEntity(usuarioPerfil.Perfil);
                    await _repositoryUsuarioPerfil.Gravar(usuarioPerfilEntity);
                }

                foreach (var role in viewModel.Roles)
                {
                    var usuarioRole = new UsuarioRoleDto
                    {
                        UsuarioId = result!.Id,
                        RoleId = role.RoleId,
                    };

                    var usuarioRoleEntity = usuarioRole.DtoForEntity();
                    await _usuarioRoleRepository.Gravar(usuarioRoleEntity);
                }

                _unitOfWork.Commit();

                if (result is not null)
                    return result.EntityForDto();

                return new UsuarioDto();
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
