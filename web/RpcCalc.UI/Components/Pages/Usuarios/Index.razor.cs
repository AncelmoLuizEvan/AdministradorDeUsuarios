using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Services.Usuarios;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class Index
    {
        [Inject]
        private IUsuarioService Service { get; set; } = null!;

        public IEnumerable<UsuarioDto>? Usuarios { get; set; } = Enumerable.Empty<UsuarioDto>();

        protected override async Task OnInitializedAsync()
        {
            var usuarios = await Service.ObterTodos();

            if (usuarios is not null && usuarios.Any())
                Usuarios = usuarios;
            else
                Usuarios = null;
        }
    }
}
