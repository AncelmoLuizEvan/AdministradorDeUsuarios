using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase;

namespace RpcCalc.UseCases.PermissaoUseCases
{
    public class PermissaoDelete : IPermissaoDelete
    {
        private readonly IPermissaoRepository _repository;
        private readonly IPermissaoRepositoryReadOnly _repositoryReadOnly;

        public PermissaoDelete(IPermissaoRepository repository, IPermissaoRepositoryReadOnly repositoryReadOnly)
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
