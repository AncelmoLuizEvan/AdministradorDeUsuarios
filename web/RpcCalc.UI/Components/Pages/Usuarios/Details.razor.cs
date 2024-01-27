using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Mappers;
using RpcCalc.UI.Services.Usuarios;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class Details
    {
        protected string _mensagem = string.Empty;

        protected UsuarioViewModel Usuario { get; set; } = new UsuarioViewModel();

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        private IUsuarioService Service { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var result = await Service.Capturar(usuarioId);

                if (result != null)
                    Usuario = result.DtoForViewModel();
            }
        }

        protected void AlterarStatus()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                Navigation.NavigateTo($"/usuario/updatestatus/{usuarioId}");
            }
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
        protected void GoToUpdate() => Navigation.NavigateTo($"/usuario/update/{Id}");
        protected void HandleFailedRequest() => _mensagem = "Ocorreu um erro, os dados do usuário não foram enviados.";
    }
}
