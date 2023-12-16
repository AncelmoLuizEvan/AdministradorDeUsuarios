using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.RoleUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.RoleUseCases
{
    public class RoleSearch : IRoleSearch
    {
        private readonly IRoleRepositoryReadOnly _repositoryReadOnly;

        public RoleSearch(IRoleRepositoryReadOnly repositoryReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<IEnumerable<RoleDto>> Listar()
        {
            var result = await _repositoryReadOnly.Listar();

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return Enumerable.Empty<RoleDto>();
        }
    }
}
