using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Mappers;
using RpcCalc.UI.Services.Usuarios;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class UpdateStatus
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        protected UsuarioInativacaoViewModel Model { get; set; } = new UsuarioInativacaoViewModel();

        [Parameter]
        public string Id { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var result = await Service.Capturar(usuarioId);

                if (result != null)
                    Model = result.DtoForUsuarioInativacaoViewModel();
            }
        }

        private async Task Save()
        {
            var result = await Service.AlterarStatus(Guid.Parse(Id), Model);

            if (result is not null)
                Navigation.NavigateTo("/usuario/list");
            else
                Model._mensagem = result;
        }
    }
}
