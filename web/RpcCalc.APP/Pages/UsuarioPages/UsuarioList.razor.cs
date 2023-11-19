using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuario;
using RpcCalc.APP.Services.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class UsuarioList
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;

        public IEnumerable<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();

        protected override async Task OnInitializedAsync()
        {
            var usuarios = await Service.ObterTodos();

            if (usuarios is not null && usuarios.Any())
                Usuarios = usuarios;
        }
    }
}
