using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Services.Authentication
{
    public interface IAuthService
    {
        Task<UsuarioLogado> Login(LoginViewModel viewModel);

        void Logout();

        Task<NovaContaViewModel?> Gravar(NovaContaViewModel viewModel);
    }
}
