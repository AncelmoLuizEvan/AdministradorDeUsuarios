﻿using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Authentication;
using RpcCalc.UI.Services.Authentication;

namespace RpcCalc.UI.Components.Pages.Logins
{
    public partial class NovaConta
    {
        [Inject]
        private IAuthService Service { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        NovaContaViewModel Model { get; set; } = new NovaContaViewModel();

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        private async Task Salvar()
        {

            var result = await Service.Gravar(Model);

            if (result is not null)
                Navigation.NavigateTo("/");
            else
                Model._mensagemPerfil = "Ocorreu um erro na API, a conta não foi criada";

        }
    }
}
