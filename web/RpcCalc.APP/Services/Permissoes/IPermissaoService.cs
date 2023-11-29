using RpcCalc.APP.Interop.Perfis;
using RpcCalc.APP.Interop.Permissoes;

namespace RpcCalc.APP.Services.Permissoes
{
    public interface IPermissaoService
    {
        Task<PermissaoDto?> Gravar(PermissaoViewModel viewModel);
        Task<bool> Excluir(Guid id);
        Task<PermissaoDto?> Capturar(Guid id);
        Task<IEnumerable<PermissaoDto>?> ObterTodos();
        Task<IEnumerable<PerfilDto>?> ObterPerfis();
    }
}
