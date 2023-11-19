using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Usuario;

namespace RpcCalc.APP.Pages.UsuarioPages
{
    public partial class UsuarioForm
    {
      
        [Inject]
        private NavigationManager NavigationManager { get; set; } = null!;

        [Parameter]
        public string? Mensagem {  get; set; }

        [EditorRequired]
        [Parameter]
        public UsuarioViewModel Usuario { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit {  get; set; }

        protected void GoToUsuarios() => NavigationManager.NavigateTo("/usuario/list");
    }
}
