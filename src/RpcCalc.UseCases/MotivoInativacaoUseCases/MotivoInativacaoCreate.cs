using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.MotivoInativacaoUseCase;
using RpcCalc.Domain.Interop.MotivoInativacao;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.MotivoInativacaoUseCases
{
    public class MotivoInativacaoCreate : IMotivoInativacaoCreate
    {
        private readonly IMotivoInativacaoRepository _repository;
        private readonly IMotivoInativacaoRepositoryReadOnly _repositoryReadOnly;

        public MotivoInativacaoCreate(IMotivoInativacaoRepository repository, IMotivoInativacaoRepositoryReadOnly repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<MotivoInativacaoDto> Execute(MotivoInativacaoViewModel viewModel)
        {
            try
            {
                var entity = viewModel.ViewModelForEntity();

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                if (result is not null)
                    return result.EntityForDto();

                return new MotivoInativacaoDto();
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                throw;
            }
        }
    }
}
