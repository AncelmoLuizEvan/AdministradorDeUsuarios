using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Usuario;
using RpcCalc.APP.Interop.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class UsuarioDetails
    {
        protected string Mensagem = string.Empty;

        protected UsuarioViewModel UsuarioViewModel { get; set; } = new UsuarioViewModel();

        [Parameter]
        public string? Id { get; set; }

        [Inject]
        private IUsuarioService UsuarioService { get; set; } = null!;
        [Inject]
        private NavigationManager _navigationManager { get; set; } = null!;


        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var result = await UsuarioService.Capturar(usuarioId);

                if (result != null)
                    UsuarioViewModel = result.DtoForViewModel();
            }
        }

        protected void GoToUsuarios() => _navigationManager.NavigateTo("/usuario/list");
        protected void GoToUpdate() => _navigationManager.NavigateTo($"/usuario/update/{Id}");

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var resulte = await UsuarioService.Excluir(usuarioId);

                if (resulte)
                    _navigationManager.NavigateTo("/usuario/list");
                else
                    Mensagem = "Ocorreu um erro, o usuário não foi excluído. ";

            }
        }

        protected void HandleFailedRequest() => Mensagem = "Ocorreu um erro, os dados do usuário não foram enviados.";

    }
}
