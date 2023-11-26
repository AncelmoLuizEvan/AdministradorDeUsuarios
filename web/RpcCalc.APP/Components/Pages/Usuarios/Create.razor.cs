using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuarios;
using RpcCalc.APP.Services.Usuarios;

namespace RpcCalc.APP.Components.Pages.Usuarios
{
    public partial class Create
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        protected string _mensagem = string.Empty;

        public UsuarioViewModel Usuario { get; set; } = new UsuarioViewModel();

        private async Task Save()
        {
            var result = await Service.Gravar(Usuario);

            if (result is not null)
                Navigation.NavigateTo("/usuario/list");
            else
                _mensagem = "Ocorreu um erro na API, o usuário não foi adicionado";
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
    }
}
