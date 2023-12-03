using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Interop.Permissoes;
using RpcCalc.APP.Interop.Usuarios;
using RpcCalc.APP.Services.Perfis;

namespace RpcCalc.APP.Components.Pages.Usuarios
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

        [Parameter]
        public Guid PermissaoId { get; set; }

        [Parameter]
        public Guid PerfilId { get; set; }

        public IEnumerable<PermissaoDto>? Permissoes { get; set; } = Enumerable.Empty<PermissaoDto>();
        public IEnumerable<PerfilDto>? Perfis { get; set; } = Enumerable.Empty<PerfilDto>();

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var perfis = await PerfilService.ObterTodos();

            if (perfis is not null && perfis.Any())
                Perfis = perfis.OrderBy(x => x.Nome);
            else
                Perfis = null;
        }

        void LoadPermissoes(ChangeEventArgs e)
        {
            PerfilId = Guid.Parse(e.Value.ToString());
            var perfilSelecionado = Perfis?.FirstOrDefault(x => x.Id == PerfilId);
            Permissoes = perfilSelecionado?.Permissoes;
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
    }
}
