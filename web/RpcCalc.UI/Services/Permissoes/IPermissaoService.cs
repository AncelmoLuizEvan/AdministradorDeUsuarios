using RpcCalc.UI.Interop.Permissoes;

namespace RpcCalc.UI.Services.Permissoes
{
    public interface IPermissaoService
    {
        Task<PermissaoDto?> Gravar(PermissaoViewModel viewModel);
        Task<bool> Excluir(Guid id);
        Task<PermissaoDto?> Capturar(Guid id);
        Task<IEnumerable<PermissaoDto>?> ObterTodos();
    }
}
