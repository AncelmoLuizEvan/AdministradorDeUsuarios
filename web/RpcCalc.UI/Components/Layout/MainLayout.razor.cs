using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Services.Caches;

namespace RpcCalc.UI.Components.Layout
{
    public partial class MainLayout
    {

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [Inject]
        private ICacheService CacheService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var token = CacheService.GetCachedToken("_token");

            if (String.IsNullOrWhiteSpace(token))
                Navigation.NavigateTo("/");
        }
    }
}
