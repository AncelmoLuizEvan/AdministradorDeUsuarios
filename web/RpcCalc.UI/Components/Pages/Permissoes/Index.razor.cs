﻿using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Permissoes;
using RpcCalc.UI.Services.Permissoes;

namespace RpcCalc.UI.Components.Pages.Permissoes
{
    public partial class Index
    {
        [Inject]
        private IPermissaoService Service { get; set; } = null!;

        public IEnumerable<PermissaoDto>? Permissoes { get; set; } = Enumerable.Empty<PermissaoDto>();

        protected override async Task OnInitializedAsync()
        {
            var permissoes = await Service.ObterTodos();

            if (permissoes is not null && permissoes.Any())
                Permissoes = permissoes;
            else
                Permissoes = null;
        }
    }
}
