using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfil;
using RpcCalc.APP.Services.Perfil;

namespace RpcCalc.APP.Pages.PerfilPages
{
    public partial class Create
    {
        [Inject]
        private IPerfilService UsuarioService { get; set; } = null!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        protected string Mensagem = string.Empty;

        public PerfilViewModel Perfil { get; set; } = new PerfilViewModel();

        private async Task Save()
        {
            var result = await UsuarioService.Gravar(Perfil);

            if (result is not null)
                NavigationManager.NavigateTo("/perfil/list");
            else
                Mensagem = "Ocorreu um erro na API, o perfil não foi adicionado";
        }

        protected void GoToUsuarios() => NavigationManager.NavigateTo("/perfil/list");
    }
}
