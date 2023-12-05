using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Perfis;
using RpcCalc.UI.Mappers;
using RpcCalc.UI.Services.Perfis;

namespace RpcCalc.UI.Components.Pages.Perfis
{
    public partial class Details
    {
        protected string _mensagem = string.Empty;

        protected PerfilViewModel Perfil { get; set; } = new PerfilViewModel();

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        private IPerfilService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var perfilId = Guid.Parse(Id);
                var result = await Service.Capturar(perfilId);

                if (result != null)
                    Perfil = result.DtoForViewModel();
            }
        }

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var perfilId = Guid.Parse(Id);
                var result = await Service.Excluir(perfilId);

                if (result)
                    Navigation.NavigateTo("/perfil/list");
                else
                    _mensagem = "Ocorreu um erro, o perfil não foi excluído. ";

            }
        }

        protected void GoToPerfis() => Navigation.NavigateTo("/perfil/list");
        protected void GoToUpdate() => Navigation.NavigateTo($"/perfil/update/{Id}");
        protected void HandleFailedRequest() => _mensagem = "Ocorreu um erro, os dados do perfil não foram enviados.";
    }
}
