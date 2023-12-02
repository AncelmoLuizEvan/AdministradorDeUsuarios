using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase;
using RpcCalc.Domain.Interop.Permissao;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.PermissaoUseCases
{
    public class PermissaoSearch : IPermissaoSearch
    {
        private readonly IPermissaoRepositoryReadOnly _repositoryReadOnly;

        public PermissaoSearch(IPermissaoRepositoryReadOnly repositoryReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<PermissaoDto?> Capturar(Guid id)
        {
            var result = await _repositoryReadOnly.Capturar(id);
            if (result is not null)
                return result.EntityForDto();

            return null;
        }

        public async Task<IEnumerable<PermissaoDto>> Listar()
        {
            var result = await _repositoryReadOnly.Listar();

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return Enumerable.Empty<PermissaoDto>();
        }
    }
}
