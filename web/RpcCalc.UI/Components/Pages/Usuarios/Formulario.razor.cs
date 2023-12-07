using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Perfis;
using RpcCalc.UI.Interop.Permissoes;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Services.Perfis;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class Formulario
    {
        [Inject]
        private IPerfilService PerfilService { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [Parameter]
        public string? _mensagem { get; set; }

        [EditorRequired]
        [Parameter]
        public UsuarioViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        [Parameter]
        public IEnumerable<PerfilDto>? Perfis { get; set; } = Enumerable.Empty<PerfilDto>();

        [Parameter]
        public IEnumerable<PermissaoDto> Permissoes { get; set; } = Enumerable.Empty<PermissaoDto>();

        string? PerfilId { get; set; }
        string? PermissaoId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var perfis = await PerfilService.ObterTodos();

            if (perfis is not null && perfis.Any())
                Perfis = perfis;
            else
                Perfis = null;
        }

        private void ObterPermissoes(ChangeEventArgs args)
        {
            if (args.Value.ToString() == "0")
            {
                Permissoes = Enumerable.Empty<PermissaoDto>();
            }
            else
            {
                var perfilSelecionado = Perfis.FirstOrDefault(x => x.Id == Guid.Parse(args.Value.ToString()));
                Permissoes = perfilSelecionado.Permissoes;
            }
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
    }
}
