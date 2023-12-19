using RpcCalc.Domain.Entities;
using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;
using SecureIdentity.Password;
using System.Data;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioCreate : IUsuarioCreate
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepository _repositoryUsuarioPerfil;
        private readonly IUsuarioRoleRepository _usuarioRoleRepository;
        private readonly IPerfilRepositoryReadOnly _perfilRepositoryReadOnly;
        private readonly IRoleRepositoryReadOnly _roleRepositoryReadOnly;

        public UsuarioCreate(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly,
            IUsuarioPerfilRepository repositoryUsuarioPerfil,
            IUsuarioRoleRepository usuarioRoleRepository,
            IPerfilRepositoryReadOnly perfilRepositoryReadOnly,
            IRoleRepositoryReadOnly roleRepositoryReadOnly)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = usuarioRepositoryReadOnly;
            _repositoryUsuarioPerfil = repositoryUsuarioPerfil;
            _usuarioRoleRepository = usuarioRoleRepository;
            _perfilRepositoryReadOnly = perfilRepositoryReadOnly;
            _roleRepositoryReadOnly = roleRepositoryReadOnly;
        }

        public async Task<UsuarioDto> Execute(UsuarioViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var senha = PasswordGenerator.Generate(16, false, true);

                var entity = viewModel.ViewModelForEntity(PasswordHasher.Hash(senha));

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
        public async Task<UsuarioDto> ExecuteNovaConta(NovaContaViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var senha = viewModel.CnpjCpf.Replace(".", "").Replace("-", "");
                viewModel.Login = viewModel.Email.Replace("@", "-").Replace(".", "-");

                var entity = viewModel.ViewModelForEntity(PasswordHasher.Hash(senha));

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                var perfis = await _perfilRepositoryReadOnly.Listar();
                var perfilSemanal = perfis.FirstOrDefault(x => x.Nome.Equals("Semana"));
                var usuarioPerfilDto = new UsuarioPerfilDto {UsuarioId = result.Id, PerfilId = perfilSemanal.Id, Perfil = "Semana" };

                await _repositoryUsuarioPerfil.Gravar(usuarioPerfilDto.DtoForEntity(usuarioPerfilDto.Perfil));

                var roles = await _roleRepositoryReadOnly.Listar();
                var roleCliente = roles.FirstOrDefault(x => x.Nome.Equals("Cliente"));
                var usuarioRoleDto = new UsuarioRoleDto { UsuarioId = result!.Id, RoleId = roleCliente.Id, };
                var usuarioRoleEntity = usuarioRoleDto.DtoForEntity();
                await _usuarioRoleRepository.Gravar(usuarioRoleEntity);

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
