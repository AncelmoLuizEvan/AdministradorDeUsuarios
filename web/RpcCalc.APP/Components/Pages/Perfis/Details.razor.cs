using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Perfis;

namespace RpcCalc.APP.Components.Pages.Perfis
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
                var usuarioId = Guid.Parse(Id);
                var result = await Service.Capturar(usuarioId);

                if (result != null)
                    Perfil = result.DtoForViewModel();
            }
        }

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var perfilId = Guid.Parse(Id);
                var resulte = await Service.Excluir(perfilId);

                if (resulte)
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
