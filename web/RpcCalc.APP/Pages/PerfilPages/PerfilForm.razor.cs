using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfil;

namespace RpcCalc.APP.Pages.PerfilPages
{
    public partial class PerfilForm
    {
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public string? Mensagem { get; set; }

        [EditorRequired]
        [Parameter]
        public PerfilViewModel Perfil { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        protected void GoToPerfis() => NavigationManager.NavigateTo("/perfil/list");
    }
}
