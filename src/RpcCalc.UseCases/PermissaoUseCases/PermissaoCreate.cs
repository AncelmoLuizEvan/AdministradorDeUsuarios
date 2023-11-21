using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase;
using RpcCalc.Domain.Interop.Permissao;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.PermissaoUseCases
{
    public class PermissaoCreate : IPermissaoCreate
    {
        private readonly IPermissaoRepository _repository;
        private readonly IPermissaoRepositoryReadOnly _repositoryReadOnly;

        public PermissaoCreate(IPermissaoRepository repository, IPermissaoRepositoryReadOnly repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<PermissaoDto> Execute(PermissaoViewModel viewModel)
        {
            try
            {
                var entity = viewModel.ViewModelForEntity();

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                if (result is not null)
                    return result.EntityForDto();

                return new PermissaoDto();
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                throw;
            }
        }
    }
}
