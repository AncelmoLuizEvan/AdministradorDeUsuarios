using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase
{
    public interface IUsuarioDelete
    {
        Task<bool> Execute(UsuarioInativacaoViewModel viewModel);
        Task<bool> Execute(Guid id, Guid idrole);
        Task<bool> Execute(Guid id, Guid idperfil, Guid? idpermissao);
    }
}
