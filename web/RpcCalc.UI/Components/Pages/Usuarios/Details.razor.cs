using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Mappers;
using RpcCalc.UI.Services.Usuarios;
using System.Reflection;

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

        protected async Task Delete()
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var usuarioId = Guid.Parse(Id);
                var result = await Service.Excluir(usuarioId);

                if (result)
                    Navigation.NavigateTo("/usuario/list");
                else
                    _mensagem = "Ocorreu um erro, o usuário não foi excluído. ";

            }
        }

        private async Task ExcluirPerfilPermissao(string idusuario, string idperfil, string idpermissao)
        {
            var usuarioId = Guid.Parse(idusuario);
            var perfilId = Guid.Parse(idperfil);
            var permissaoId = Guid.Parse(idpermissao);

            var result = await Service.ExcluirUsuarioPerfil(usuarioId, perfilId, permissaoId);

            if (result)
            {
                var usuarioPerfil = Usuario.UsuarioPerfis.FirstOrDefault(x => x.PerfilId == perfilId && x.PermissaoId == permissaoId);

                if (usuarioPerfil == null)
                    return;

                Usuario.UsuarioPerfis.Remove(usuarioPerfil);
            }
            else
                _mensagem = "Ocorreu um erro, o usuário não foi excluído. ";
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
        protected void GoToUpdate() => Navigation.NavigateTo($"/usuario/update/{Id}");
        protected void HandleFailedRequest() => _mensagem = "Ocorreu um erro, os dados do usuário não foram enviados.";
    }
}
