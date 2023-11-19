using Microsoft.AspNetCore.Components;
using RpcCalc.APP.Interop.Perfil;
using RpcCalc.APP.Services.Perfil;

namespace RpcCalc.APP.Pages.PerfilPages
{
    public partial class PerfilList
    {
        [Inject]
        private IPerfilService Service { get; set; } = null!;

        public IEnumerable<PerfilDto> Perfis { get; set; } = new List<PerfilDto>();

        protected override async Task OnInitializedAsync()
        {
            var perfis = await Service.ObterTodos();

            if (perfis is not null && perfis.Any())
                Perfis = perfis;
        }
    }
}
