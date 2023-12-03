using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Interop.Permissoes;
using RpcCalc.APP.Services.Perfis;
using RpcCalc.APP.Services.Permissoes;

namespace RpcCalc.APP.Components.Pages.Usuarios
{
    public partial class SelectPermissaoPerfil
    {
        [Inject]
        private IPermissaoService PermissaoService { get; set; } = null!;

        [Inject]
        private IPerfilService PerfilService { get; set; } = null!;

        public IEnumerable<PermissaoDto>? Permissoes { get; set; } = Enumerable.Empty<PermissaoDto>();
        public IEnumerable<PerfilDto>? Perfis { get; set; } = Enumerable.Empty<PerfilDto>();

        public Guid PermissaoId { get; set; }
        
        [Parameter]
        public Guid PerfilId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var perfis = await PerfilService.ObterTodos();

            if (perfis is not null && perfis.Any())
                Perfis = perfis.OrderBy(x => x.Nome);
            else
                Perfis = null;
        }

        private async Task LoadPermissoes()
        {
            var perfilSelecionado = Perfis?.FirstOrDefault(x => x.Id == PerfilId);
            Permissoes = perfilSelecionado?.Permissoes;
        }


    }
}
