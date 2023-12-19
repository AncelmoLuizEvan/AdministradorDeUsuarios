using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Components.Pages.Logins
{
    public partial class FormularioNovaConta
    {

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public NovaContaViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        protected void GoToLogin() => Navigation.NavigateTo("/");
    }
}
