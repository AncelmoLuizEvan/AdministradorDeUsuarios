using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Services.Authentication
{
    public interface IAuthService
    {
        Task<UsuarioLogado> Login(LoginViewModel viewModel);

        void Logout();

        Task<NovaContaDto?> Gravar(NovaContaViewModel viewModel);
    }
}
