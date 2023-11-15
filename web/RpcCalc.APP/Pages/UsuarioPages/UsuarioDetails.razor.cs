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
        protected UsuarioDto UsuarioDto { get; set; } = new UsuarioDto();

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

        protected void GoToUsuarios() => _navigationManager.NavigateTo("/usuarios");

        protected async Task ExcluirUsuario()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var resulte = await UsuarioService.Excluir(usuarioId);

                if (resulte)
                    _navigationManager.NavigateTo("/usuarios");
                else
                    Mensagem = "Ocorreu um erro, o usuário não foi excluído. ";

            }
        }

        protected async Task HandleValidRequest()
        {
            if (string.IsNullOrEmpty(Id))
            {
                var result = await UsuarioService.Gravar(UsuarioViewModel);

                if (result is not null)
                    _navigationManager.NavigateTo("/usuarios");
                else
                    Mensagem = "Ocorreu um erro, o usuário não foi adicionado";
            }
            else
            {
                var result = await UsuarioService.Alterar(Guid.Parse(Id), UsuarioViewModel);

                if (result is not null)
                    _navigationManager.NavigateTo("/usuarios");
                else
                    Mensagem = "Ocorreu um erro, o usuário não foi atualizado";
            }
        }

        protected void HandleFailedRequest() => Mensagem = "Ocorreu um erro, os dados do usuário não foram enviados.";

    }
}
