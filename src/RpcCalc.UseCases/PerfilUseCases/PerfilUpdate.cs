using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase;
using RpcCalc.Domain.Interop.Perfil;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.PerfilUseCases
{
    public class PerfilUpdate : IPerfilUpdate
    {
        private readonly IPerfilRepository _repository;
        private readonly IPerfilRepositoryReadOnly _repositoryReadOnly;

        public PerfilUpdate(IPerfilRepository repository, IPerfilRepositoryReadOnly repositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<PerfilDto> Execute(Guid id, PerfilViewModel viewModel)
        {
            try
            {
                var perfil = await _repositoryReadOnly.Capturar(id);

                perfil!.AtualizarDados(viewModel.Nome, viewModel.Descricao);

                await _repository.Alterar(perfil);

                return perfil.EntityForDto();
            }
            catch (Exception ex)
            {
                var logErro = ex.Message;
                throw;
            }
        }
    }
}
