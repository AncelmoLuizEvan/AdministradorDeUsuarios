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

        public UsuarioDelete(IUnitOfWork unitOfWork,
            IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepositoryReadOnly usuarioPerfilRepositoryReadOnly,
            IUsuarioPerfilRepository usuarioPerfilRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _usuarioPerfilRepositoryReadOnly = usuarioPerfilRepositoryReadOnly;
            _usuarioPerfilRepository = usuarioPerfilRepository;
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

        public async Task<bool> Execute(Guid id, Guid idperfil, Guid idpermissao)
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
    }
}
