using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Services.Caches;

namespace RpcCalc.UI.Components.Pages
{
    public partial class Home
    {
        [Inject]
        private ICacheService CacheService { get; set; } = null!;

        private string NomeUsuario { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var usuarioLogadoCached = CacheService.GetCachedToken("_token");

            if (usuarioLogadoCached is not null)
                NomeUsuario = usuarioLogadoCached.Usuario.Nome;
        }
    }
}
