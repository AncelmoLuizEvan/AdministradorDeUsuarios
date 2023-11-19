using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuario;
using RpcCalc.APP.Services.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class UsuarioCreate
    {
        [Inject]
        private IUsuarioService UsuarioService { get; set; } = null!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        protected string Mensagem = string.Empty;

        public UsuarioViewModel UsuarioViewModel { get; set; } = new UsuarioViewModel();

        private async Task Create()
        {
            var result = await UsuarioService.Gravar(UsuarioViewModel);

            if (result is not null)
                NavigationManager.NavigateTo("/usuario/list");
            else
                Mensagem = "Ocorreu um erro na API, o usuário não foi adicionado";
        }

        protected void GoToUsuarios() => NavigationManager.NavigateTo("/usuario/list");
    }
}

