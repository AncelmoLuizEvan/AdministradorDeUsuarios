using RpcCalc.Domain.Interop.Authentication;

namespace RpcCalc.Domain.Interfaces.UseCases.AuthenticationUseCase
{
    public interface INovaContaCreate
    {
        Task<NovaContaDto> Execute(NovaContaViewModel viewModel);
    }
}
