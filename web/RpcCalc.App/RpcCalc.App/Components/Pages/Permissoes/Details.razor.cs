using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Permissoes;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Permissoes;

namespace RpcCalc.App.Components.Pages.Permissoes
{
    public partial class Details
    {
        protected string _mensagem = string.Empty;

        protected PermissaoViewModel Permissao { get; set; } = new PermissaoViewModel();

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        private IPermissaoService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var permissaoId = Guid.Parse(Id);
                var result = await Service.Capturar(permissaoId);

                if (result != null)
                    Permissao = result.DtoForViewModel();
            }
        }

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var permissaoId = Guid.Parse(Id);
                var result = await Service.Excluir(permissaoId);

                if (result)
                    Navigation.NavigateTo("/permissao/list");
                else
                    _mensagem = "Ocorreu um erro, a permissão não foi excluído. ";

            }
        }

        protected void GoToPermissoes() => Navigation.NavigateTo("/permissao/list");
        protected void GoToUpdate() => Navigation.NavigateTo($"/permissao/update/{Id}");
        protected void HandleFailedRequest() => _mensagem = "Ocorreu um erro, os dados da permissão não foram enviados.";
    }
}
