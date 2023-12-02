using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Services.Perfis;

namespace RpcCalc.APP.Components.Pages.Perfis
{
    public partial class Create
    {
        [Inject]
        private IPerfilService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        protected string _mensagem = string.Empty;

        public PerfilViewModel Perfil { get; set; } = new PerfilViewModel();

        private async Task Save()
        {
            var result = await Service.Gravar(Perfil);

            if (result is not null)
                Navigation.NavigateTo("/perfil/list");
            else
                _mensagem = "Ocorreu um erro na API, o perfil não foi adicionado";
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/perfil/list");
    }
}
