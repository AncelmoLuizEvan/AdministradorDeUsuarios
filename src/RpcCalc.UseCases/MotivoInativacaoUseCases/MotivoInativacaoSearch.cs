using RpcCalc.Domain.Interfaces.RepositoriesReadOnly;
using RpcCalc.Domain.Interfaces.UseCases.MotivoInativacaoUseCase;
using RpcCalc.Domain.Interop.MotivoInativacao;
using RpcCalc.Domain.Mappers;

namespace RpcCalc.UseCases.MotivoInativacaoUseCases
{
    public class MotivoInativacaoSearch : IMotivoInativacaoSearch
    {
        private readonly IMotivoInativacaoRepositoryReadOnly _repositoryReadOnly;

        public MotivoInativacaoSearch(IMotivoInativacaoRepositoryReadOnly repositoryReadOnly)
        {
            _repositoryReadOnly = repositoryReadOnly;
        }

        public async Task<IEnumerable<MotivoInativacaoDto>> Listar(Guid usuarioId)
        {
            var result = await _repositoryReadOnly.ListarPorUsuario(usuarioId);

            if (result!.Any() && result!.Count() > 0)
                return result!.EntityForDtoList();

            return new List<MotivoInativacaoDto>();
        }
    }
}
