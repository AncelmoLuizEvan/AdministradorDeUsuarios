using RpcCalc.Domain.Interfaces.Repositories;
using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioCreate : IUsuarioCreate
    {
        private readonly IUsuarioRepository _repository;
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;

        public UsuarioCreate(IUsuarioRepository repository,
            IUsuarioRepositoryReadOnly usuarioRepositoryReadOnly)
        {
            _repository = repository;
            _repositoryReadOnly = usuarioRepositoryReadOnly;
        }

        public async Task<UsuarioDto> Execute(UsuarioViewModel viewModel)
        {
            try
            {
                var entity = viewModel.ViewModelForEntity();

                await _repository.Gravar(entity);

                var result = await _repositoryReadOnly.Capturar(entity.Id);

                if (result is not null)
                    return result.EntityForDto();

                return new UsuarioDto();
            }
            catch (Exception ex)
            {
                var logError = ex.ToString();
                throw;
            }

        }
    }
}
