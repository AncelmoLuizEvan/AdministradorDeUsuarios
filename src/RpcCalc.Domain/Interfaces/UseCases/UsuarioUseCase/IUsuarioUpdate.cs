using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase
{
    public interface IUsuarioUpdate
    {
        Task<UsuarioDto> Execute(Guid id, UsuarioViewModel viewModel);
    }
}
