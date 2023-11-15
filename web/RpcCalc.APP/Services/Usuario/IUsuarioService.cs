using RpcCalc.APP.Interop.Usuario;

namespace RpcCalc.APP.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<UsuarioDto?> Gravar(UsuarioViewModel viewModel);
        Task<UsuarioDto?> Alterar(Guid id, UsuarioViewModel viewModel);
        Task<bool> Excluir(Guid id);
        Task<UsuarioDto?> Capturar(Guid id);
        Task<IEnumerable<UsuarioDto>?> ObterTodos();
    }
}
