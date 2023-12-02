using RpcCalc.Domain.Interop.MotivoInativacao;

namespace RpcCalc.Domain.Interfaces.UseCases.MotivoInativacaoUseCase
{
    public interface IMotivoInativacaoCreate
    {
        Task<MotivoInativacaoDto> Execute(MotivoInativacaoViewModel viewModel);
    }
}
