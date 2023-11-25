using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfil;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Perfil;

namespace RpcCalc.APP.Pages.PerfilPages
{
    public partial class Update
    {
        [Inject]
        private IPerfilService PerfilService { get; set; } = null!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;
        protected PerfilViewModel Perfil { get; set; } = new PerfilViewModel();

        protected string Mensagem = string.Empty;

        [Parameter]
        public string Id { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var perfilId = Guid.Parse(Id);
                var result = await PerfilService.Capturar(perfilId);

                if (result != null)
                    Perfil = result.DtoForViewModel();
            }
        }

        private async Task Save()
        {
            var result = await PerfilService.Alterar(Guid.Parse(Id), Perfil);

            if (result is not null)
                NavigationManager.NavigateTo("/perfil/list");
            else
                Mensagem = "Ocorreu um erro, o perfil não foi atualizado";
        }
    }
}
