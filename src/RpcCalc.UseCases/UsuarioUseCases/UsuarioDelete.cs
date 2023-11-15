using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioDelete : IUsuarioDelete
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;

        public UsuarioDelete(IUsuarioRepository repository, IUsuarioRepositoryReadOnly repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
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
    }
}
