using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Perfis;

namespace RpcCalc.APP.Components.Pages.Perfis
{
    public partial class Update
    {
        [Inject]
        private IPerfilService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;
        protected PerfilViewModel Perfil { get; set; } = new PerfilViewModel();

        protected string _mensagem = string.Empty;

        [Parameter]
        public string Id { get; set; } = null!;

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

        private async Task Save()
        {
            var result = await Service.Alterar(Guid.Parse(Id), Perfil);

            if (result is not null)
                Navigation.NavigateTo("/perfil/list");
            else
                _mensagem = "Ocorreu um erro, o perfil não foi atualizado";
        }
    }
}
