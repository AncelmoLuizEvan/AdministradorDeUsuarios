using RpcCalc.Domain.Interop.Perfil;

namespace RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase
{
    public interface IPerfilUpdate
    {
        Task<PerfilDto> Execute(Guid id, PerfilViewModel viewModel);
    }
}
