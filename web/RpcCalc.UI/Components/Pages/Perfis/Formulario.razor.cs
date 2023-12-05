using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Perfis;

namespace RpcCalc.UI.Components.Pages.Perfis
{
    public partial class Formulario
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public string? _mensagem { get; set; }

        [EditorRequired]
        [Parameter]
        public PerfilViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        protected void GoToPerfis() => NavigationManager.NavigateTo("/perfil/list");
    }
}
