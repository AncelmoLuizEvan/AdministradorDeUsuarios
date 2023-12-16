using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Mappers;
using RpcCalc.UI.Services.Usuarios;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class Update
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;
        protected UsuarioViewModel Usuario { get; set; } = new UsuarioViewModel();

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
            if (Usuario.UsuarioPerfis.Count() == 0)
            {
                Usuario._mensagemPerfil = "Adicione uma ou mais permissões para o usuário";
            }
            else
            {
                var result = await Service.Alterar(Guid.Parse(Id), Usuario);

                if (result is not null)
                    Navigation.NavigateTo("/usuario/list");
                else
                    Usuario._mensagemPerfil = "Ocorreu um erro, o usuário não foi atualizado";
            }

        }
    }
}
