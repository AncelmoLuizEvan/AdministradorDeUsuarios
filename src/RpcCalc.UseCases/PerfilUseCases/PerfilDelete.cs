using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase;

namespace RpcCalc.UseCases.PerfilUseCases
{
    public class PerfilDelete : IPerfilDelete
    {
        private readonly IPerfilRepository _repository;
        private readonly IPerfilRepositoryReadOnly _repositoryReadOnly;

        public PerfilDelete(IPerfilRepository repository, IPerfilRepositoryReadOnly repositoryReadOnly)
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
