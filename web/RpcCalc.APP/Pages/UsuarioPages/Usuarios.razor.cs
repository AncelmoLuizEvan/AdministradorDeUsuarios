using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Services.Usuario;
using RpcCalc.APP.Interop.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class Usuarios
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;

        public IEnumerable<UsuarioDto> UsuariosCadastrados { get; set; } = new List<UsuarioDto>();

        protected override async Task OnInitializedAsync()
        {
            var usuarios = await Service.ObterTodos();

            if (usuarios is not null && usuarios.Any())
                UsuariosCadastrados = usuarios;
        }
    }
}
