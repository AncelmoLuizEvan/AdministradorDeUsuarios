using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Interop.Permissoes;
using RpcCalc.APP.Services.Perfis;
using RpcCalc.APP.Services.Permissoes;

namespace RpcCalc.APP.Components.Pages.Permissoes
{
    public partial class Formulario
    {
        [Inject]
        private IPermissaoService Service { get; set; } = null!;

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

        protected override async void OnInitialized()
        {
            Perfis = await Service.ObterPerfis();
        }
        protected void GoToPermissoes() => NavigationManager.NavigateTo("/permissao/list");
    }
}
