using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase;
using RpcCalc.Domain.Interop.Perfil;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.PerfilUseCases
{
    public class PerfilSearch : IPerfilSearch
    {
        private readonly IPerfilRepositoryReadOnly _repositoryReadOnly;

        public PerfilSearch(IPerfilRepositoryReadOnly repositoryReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<PerfilDto?> Capturar(Guid id)
        {
            var result = await _repositoryReadOnly.Capturar(id);
            if (result is not null)
                return result.EntityForDto();

            return null;
        }

        public async Task<IEnumerable<PerfilDto>> Listar()
        {
            var result = await _repositoryReadOnly.Listar();

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return new List<PerfilDto>();
        }
    }
}
