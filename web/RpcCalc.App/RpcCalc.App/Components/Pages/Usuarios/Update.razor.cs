using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuarios;
using RpcCalc.APP.Mappers;
using RpcCalc.APP.Services.Usuarios;

namespace RpcCalc.App.Components.Pages.Usuarios
{
    public partial class Update
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;
        protected UsuarioViewModel Usuario { get; set; } = new UsuarioViewModel();

        protected string Mensagem = string.Empty;

        [Parameter]
        public string Id { get; set; } = null!;

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

        private async Task Save()
        {
            var result = await Service.Alterar(Guid.Parse(Id), Usuario);

            if (result is not null)
                Navigation.NavigateTo("/usuario/list");
            else
                Mensagem = "Ocorreu um erro, o usuário não foi atualizado";
        }
    }
}
