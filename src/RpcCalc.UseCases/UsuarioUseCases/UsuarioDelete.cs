using RpcCalc.Domain.Interfaces;
using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioDelete : IUsuarioDelete
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepositoryReadOnly _usuarioPerfilRepositoryReadOnly;
        private readonly IUsuarioPerfilRepository _usuarioPerfilRepository;
        private readonly IUsuarioRoleRepository _usuarioRoleRepository;
        private readonly IUsuarioRoleRepositoryReadOnly _usuarioRoleRepositoryReadOnly;


        public UsuarioDelete(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepositoryReadOnly usuarioPerfilRepositoryReadOnly,
            IUsuarioPerfilRepository usuarioPerfilRepository,
            IUsuarioRoleRepository usuarioRoleRepository,
            IUsuarioRoleRepositoryReadOnly usuarioRoleRepositoryReadOnly)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _usuarioPerfilRepositoryReadOnly = usuarioPerfilRepositoryReadOnly;
            _usuarioPerfilRepository = usuarioPerfilRepository;
            _usuarioRoleRepository = usuarioRoleRepository;
            _usuarioRoleRepositoryReadOnly = usuarioRoleRepositoryReadOnly;
        }

        public async Task<bool> Execute(Guid id)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var result = await _repositoryReadOnly.Capturar(id);

                foreach (var item in result!.UsuarioPerfis)
                {
                    await _usuarioPerfilRepository.Excluir(item);
                }

                if (result is not null)
                    await _repository.Excluir(result);

                _unitOfWork.Commit();

                return true;
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                _unitOfWork.Rollback();
                return false;
                throw;
            }

        }

        public async Task<bool> Execute(Guid id, Guid idperfil, Guid? idpermissao)
        {
            try
            {
                var result = await _usuarioPerfilRepositoryReadOnly.CapiturarPermissaoDoUsuario(id, idperfil, idpermissao);

                if (result is not null)
                    await _usuarioPerfilRepository.Excluir(result);

                return true;
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                return false;
                throw;
            }
        }

        public async Task<bool> Execute(Guid id, Guid idrole)
        {
            try
            {
                var result = await _usuarioRoleRepositoryReadOnly.CapiturarRoleDoUsuario(id, idrole);

                if (result is not null)
                    await _usuarioRoleRepository.Excluir(result);

                return true;
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                return false;
                throw;
            }
        }
    }
}
