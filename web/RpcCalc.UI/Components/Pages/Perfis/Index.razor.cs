using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Perfis;
using RpcCalc.UI.Services.Perfis;

namespace RpcCalc.UI.Components.Pages.Perfis
{
    public partial class Index
    {
        [Inject]
        private IPerfilService Service { get; set; } = null!;

        public IEnumerable<PerfilDto>? Perfis { get; set; } = Enumerable.Empty<PerfilDto>();

        protected override async Task OnInitializedAsync()
        {
            var perfis = await Service.ObterTodos();

            if (perfis is not null && perfis.Any())
                Perfis = perfis;
            else
                Perfis = null;
        }
    }
}
