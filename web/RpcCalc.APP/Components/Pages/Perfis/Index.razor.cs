using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Services.Perfis;

namespace RpcCalc.APP.Components.Pages.Perfis
{
    public partial class Index
    {
        [Inject]
        private IPerfilService Service { get; set; } = null!;

        public IEnumerable<PerfilDto>? Perfis { get; set; } = new List<PerfilDto>();

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
