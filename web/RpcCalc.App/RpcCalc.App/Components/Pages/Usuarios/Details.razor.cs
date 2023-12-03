using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuarios;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Usuarios;

namespace RpcCalc.App.Components.Pages.Usuarios
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

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var resulte = await Service.Excluir(usuarioId);

                if (resulte)
                    Navigation.NavigateTo("/usuario/list");
                else
                    _mensagem = "Ocorreu um erro, o usuário não foi excluído. ";

            }
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
        protected void GoToUpdate() => Navigation.NavigateTo($"/usuario/update/{Id}");
        protected void HandleFailedRequest() => _mensagem = "Ocorreu um erro, os dados do usuário não foram enviados.";
    }
}
