using RpcCalc.APP.Interop.Perfil;

namespace RpcCalc.APP.Services.Perfil
{
    public interface IPerfilService
    {
        Task<PerfilDto?> Gravar(PerfilViewModel viewModel);
        Task<PerfilDto?> Alterar(Guid id, PerfilViewModel viewModel);
        Task<bool> Excluir(Guid id);
        Task<PerfilDto?> Capturar(Guid id);
        Task<IEnumerable<PerfilDto>?> ObterTodos();
    }
}
