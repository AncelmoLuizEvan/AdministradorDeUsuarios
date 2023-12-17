using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Authentication;

namespace RpcCalc.UI.Components.Pages.Logins
{
    public partial class Formulario
    {
        [Parameter]
        public string? _mensagem { get; set; }

        [EditorRequired]
        [Parameter]
        public LoginViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }
    }
}
