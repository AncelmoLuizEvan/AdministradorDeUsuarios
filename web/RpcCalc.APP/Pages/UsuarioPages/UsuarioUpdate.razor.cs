using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuario;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class UsuarioUpdate
    {
        [Inject]
        private IUsuarioService UsuarioService { get; set; } = null!;
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;
        protected UsuarioViewModel UsuarioViewModel { get; set; } = new UsuarioViewModel();

        protected string Mensagem = string.Empty;

        [Parameter]
        public string Id { get; set; } = null!;

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

        private async Task Update()
        {
            var result = await UsuarioService.Alterar(Guid.Parse(Id), UsuarioViewModel);

            if (result is not null)
                NavigationManager.NavigateTo("/usuario/list");
            else
                Mensagem = "Ocorreu um erro, o usuário não foi atualizado";
        }
    }
}
