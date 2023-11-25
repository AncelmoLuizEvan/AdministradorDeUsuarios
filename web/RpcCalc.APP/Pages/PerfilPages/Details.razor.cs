using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfil;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Perfil;

namespace RpcCalc.APP.Pages.PerfilPages
{
    public partial class Details
    {
        protected string Mensagem = string.Empty;

        protected PerfilViewModel Perfil { get; set; } = new PerfilViewModel();

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        private IPerfilService PerfilService { get; set; } = null!;
        [Inject]
        private NavigationManager _navigationManager { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var result = await PerfilService.Capturar(usuarioId);

                if (result != null)
                    Perfil = result.DtoForViewModel();
            }
        }

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var perfilId = Guid.Parse(Id);
                var resulte = await PerfilService.Excluir(perfilId);

                if (resulte)
                    _navigationManager.NavigateTo("/perfil/list");
                else
                    Mensagem = "Ocorreu um erro, o perfil não foi excluído. ";

            }
        }

        protected void GoToPerfis() => _navigationManager.NavigateTo("/perfil/list");
        protected void GoToUpdate() => _navigationManager.NavigateTo($"/perfil/update/{Id}");
        protected void HandleFailedRequest() => Mensagem = "Ocorreu um erro, os dados do perfil não foram enviados.";
    }
}
