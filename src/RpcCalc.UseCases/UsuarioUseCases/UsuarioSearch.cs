using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase;
using RpcCalc.Domain.Interop.Usuario;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.UsuarioUseCases
{
    public class UsuarioSearch : IUsuarioSearch
    {
        private readonly IUsuarioRepositoryReadOnly _repositoryReadOnly;

        public UsuarioSearch(IUsuarioRepositoryReadOnly repositoryReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<UsuarioDto?> Capturar(Guid id)
        {
            var result = await _repositoryReadOnly.Capturar(id);
            if (result is not null)
                return result.EntityForDto();

            return null;
        }

        public async Task<IEnumerable<UsuarioDto>?> Listar()
        {
            var result = await _repositoryReadOnly.Listar();

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return Enumerable.Empty<UsuarioDto>();
        }
    }
}
