using RpcCalc.Domain.Interop.MotivoInativacao;

namespace RpcCalc.Domain.Interfaces.UseCases.MotivoInativacaoUseCase
{
    public interface IMotivoInativacaoSearch
    {
        Task<IEnumerable<MotivoInativacaoDto>> Listar(Guid usuarioId);
    }
}
