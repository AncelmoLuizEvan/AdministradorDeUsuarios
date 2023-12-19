using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase
{
    public interface IUsuarioCreate
    {
        Task<UsuarioDto> Execute(UsuarioViewModel viewModel);
    }
}
