using Microsoft.AspNetCore.Components;
using RpcCalc.UI.Interop.Perfis;
using RpcCalc.UI.Interop.Permissoes;
using RpcCalc.UI.Interop.Usuarios;
using RpcCalc.UI.Services.Perfis;
using RpcCalc.UI.Services.Permissoes;

namespace RpcCalc.UI.Components.Pages.Usuarios
{
    public partial class Formulario
    {
        [Inject]
        private IPerfilService PerfilService { get; set; } = null!;

        [Inject]
        private IPermissaoService PermissaoService { get; set; } = null!;

        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [Parameter]
        public string? _mensagem { get; set; }

        [Parameter]
        public string? _erroAddPerfilPermissao { get; set; }

        [EditorRequired]
        [Parameter]
        public UsuarioViewModel Model { get; set; } = null!;

        [EditorRequired]
        [Parameter]
        public EventCallback OnValidateSubmit { get; set; }

        [Parameter]
        public IEnumerable<PerfilDto>? Perfis { get; set; } = Enumerable.Empty<PerfilDto>();

        [Parameter]
        public IEnumerable<PermissaoDto>? Permissoes { get; set; } = Enumerable.Empty<PermissaoDto>();

        private UsuarioPerfilDto? UsuarioPerfil { get; set; }

        string PerfilId { get; set; } = string.Empty;
        string PermissaoId { get; set; } = string.Empty;

        string DescricaoPerfil { get; set; } = string.Empty;
        string DescricaoPermissao { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            var perfis = await PerfilService.ObterTodos();
            var permissoes = await PermissaoService.ObterTodos();

            if (perfis is not null && perfis.Any())
                Perfis = perfis;
            else
                Perfis = null;

            if (permissoes is not null && permissoes.Any())
                Permissoes = permissoes;
            else
                Permissoes = null;
        }

        private void ObterPermissoes(ChangeEventArgs args)
        {
            if (args.Value.ToString() == "0")
            {
                DescricaoPerfil = string.Empty;
                PerfilId = string.Empty;
            }
            else
            {
                var perfilSelecionado = Perfis!.FirstOrDefault(x => x.Id == Guid.Parse(args.Value.ToString()));
                PerfilId = perfilSelecionado.Id.ToString();
                DescricaoPerfil = perfilSelecionado.Nome!;
            }
        }

        private void ObterPermissaoSelecionada(ChangeEventArgs args)
        {
            if (args.Value.ToString() == "0")
            {
                DescricaoPermissao = string.Empty;
                PermissaoId = string.Empty;
            }
            else
            {
                var permissaoSelecionada = Permissoes.FirstOrDefault(x => x.Id == Guid.Parse(args.Value.ToString()));
                DescricaoPermissao = permissaoSelecionada.Sistema;
                PermissaoId = permissaoSelecionada.Id.ToString();
            }
        }

        private void AdicionarPerfilPermissao()
        {
            try
            {
                if (String.IsNullOrEmpty(DescricaoPerfil))
                {
                    _erroAddPerfilPermissao = "Selecione o Perfil";
                    return;
                }

                if (String.IsNullOrEmpty(DescricaoPermissao))
                {
                    _erroAddPerfilPermissao = "Selecione a Permissão";
                    return;
                }

                UsuarioPerfil = new UsuarioPerfilDto
                {
                    Perfil = DescricaoPerfil,
                    Permissao = DescricaoPermissao,
                    PerfilId = Guid.Parse(PerfilId),
                    PermissaoId = Guid.Parse(PermissaoId)
                };

                Model.UsuarioPerfis.Add(UsuarioPerfil);

                _erroAddPerfilPermissao = string.Empty;
            }
            catch
            {
                _erroAddPerfilPermissao = "Selecione um Perfil e uma Permissão";
            }
        }

        private void ExcluirPerfilPermissao(string id)
        {
            var perfilId = Guid.Parse(id);

            var usuarioPerfil = Model.UsuarioPerfis.FirstOrDefault(x => x.PerfilId == perfilId);

            if (usuarioPerfil == null)
                return;

            Model.UsuarioPerfis.Remove(usuarioPerfil);
        }

        private void LimparListas()
        {
            Model.UsuarioPerfis = new List<UsuarioPerfilDto>();
            DescricaoPerfil = string.Empty;
            DescricaoPermissao = string.Empty;
            PerfilId = string.Empty;
        }

        protected void GoToUsuarios() => Navigation.NavigateTo("/usuario/list");
    }
}
