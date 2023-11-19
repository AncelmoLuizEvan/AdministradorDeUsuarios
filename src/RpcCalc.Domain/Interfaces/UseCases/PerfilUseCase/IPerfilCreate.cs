using RpcCalc.Domain.Interop.Perfil;

namespace RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase
{
    public interface IPerfilCreate
    {
        Task<PerfilDto> Execute(PerfilViewModel viewModel);
    }
}
