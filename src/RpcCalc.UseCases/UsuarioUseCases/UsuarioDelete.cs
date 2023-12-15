using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioDelete : IUsuarioDelete
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;
        private readonly IUsuarioPerfilRepositoryReadOnly _usuarioPerfilRepositoryReadOnly;
        private readonly IUsuarioPerfilRepository _usuarioPerfilRepository;

        public UsuarioDelete(IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly repositoryReadOnly,
            IUsuarioPerfilRepositoryReadOnly usuarioPerfilRepositoryReadOnly,
            IUsuarioPerfilRepository usuarioPerfilRepository)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
            _usuarioPerfilRepositoryReadOnly = usuarioPerfilRepositoryReadOnly;
            _usuarioPerfilRepository = usuarioPerfilRepository;
        }

        public async Task<bool> Execute(Guid id)
        {
            try
            {
                var result = await _repositoryReadOnly.Capturar(id);

                if (result is not null)
                    await _repository.Excluir(result);

                return true;
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
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
