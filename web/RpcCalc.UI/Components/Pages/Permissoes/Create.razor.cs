using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Permissoes;
using RpcCalc.UI.Services.Permissoes;

namespace RpcCalc.UI.Components.Pages.Permissoes
{
    public partial class Create
    {
        [Inject]
        private IPermissaoService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        protected string _mensagem = string.Empty;

        public PermissaoViewModel Permissao { get; set; } = new PermissaoViewModel();

        private async Task Save()
        {
            var result = await Service.Gravar(Permissao);

            if (result is not null)
                Navigation.NavigateTo("/permissao/list");
            else
                _mensagem = "Ocorreu um erro na API, o perfil não foi adicionado";
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/permissao/list");
    }
}
