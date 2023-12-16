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

        public UsuarioCreate(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly,
            IUsuarioPerfilRepository repositoryUsuarioPerfil)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = usuarioRepositoryReadOnly;
            _repositoryUsuarioPerfil = repositoryUsuarioPerfil;
        }

        public async Task<UsuarioDto> Execute(UsuarioViewModel viewModel)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var senha = PasswordGenerator.Generate(25, true, true);

                var entity = viewModel.ViewModelForEntity(PasswordHasher.Hash(senha));

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                foreach (var usuarioPerfil in viewModel.UsuarioPerfis)
                {
                    usuarioPerfil.UsuarioId = result!.Id;

                    var usuarioPerfilEntity = usuarioPerfil.DtoForEntity(usuarioPerfil.Perfil);
                    await _repositoryUsuarioPerfil.Gravar(usuarioPerfilEntity);
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
