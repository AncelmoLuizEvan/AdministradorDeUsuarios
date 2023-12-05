﻿using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Usuarios;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class Formulario
    {
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

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
    }
}
