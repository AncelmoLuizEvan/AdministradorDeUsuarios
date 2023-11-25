using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuario;
using RpcCalc.APP.Services.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class Create
    {
        [Inject]
        private IUsuarioService UsuarioService { get; set; } = null!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        protected string Mensagem = string.Empty;

        public UsuarioViewModel Usuario { get; set; } = new UsuarioViewModel();

        private async Task Save()
        {
            var result = await UsuarioService.Gravar(Usuario);

            if (result is not null)
                NavigationManager.NavigateTo("/usuario/list");
            else
                Mensagem = "Ocorreu um erro na API, o usuário não foi adicionado";
        }

        protected void GoToUsuarios() => NavigationManager.NavigateTo("/usuario/list");
    }
}

