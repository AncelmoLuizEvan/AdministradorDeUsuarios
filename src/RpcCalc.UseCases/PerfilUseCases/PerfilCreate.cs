using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase;
using RpcCalc.Domain.Interop.Perfil;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.PerfilUseCases
{
    public class PerfilCreate : IPerfilCreate
    {
        private readonly IPerfilRepository _repository;
        private readonly IPerfilRepositoryReadOnly _repositoryReadOnly;

        public PerfilCreate(IPerfilRepository repository, IPerfilRepositoryReadOnly repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async     Task<PerfilDto> Execute(PerfilViewModel viewModel)
        {
            try
            {
                var entity = viewModel.ViewModelForEntity();

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                if (result is not null)
                    return result.EntityForDto();

                return new PerfilDto();
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                throw;
            }
        }
    }
}
