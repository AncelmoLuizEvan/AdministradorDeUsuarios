using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Perfis;
using RpcCalc.UI.Interop.Permissoes;
using RpcCalc.UI.Services.Perfis;

namespace RpcCalc.UI.Components.Pages.Permissoes
{
    public partial class Formulario
    {
        [Inject]
        private IPerfilService Service { get; set; } = null!;

        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public string? _mensagem { get; set; }

        [EditorRequired]
        [Parameter]
        public PermissaoViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        [Parameter]
        public IEnumerable<PerfilDto>? Perfis { get; set; } = Enumerable.Empty<PerfilDto>();

        protected override async Task OnInitializedAsync()
        {
            Perfis = await Service.ObterTodos();
        }
        protected void GoToPermissoes() => NavigationManager.NavigateTo("/permissao/list");
    }
}
