using RpcCalc.Domain.Interop.Usuario;

namespace RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase
{
    public interface IUsuarioSearch
    {
        Task<IEnumerable<UsuarioDto>?> Listar();
        Task<UsuarioDto?> Capturar(Guid id);
        Task<LoginDto?> ValidarLogin(string email, string senha);
        Task<UsuarioDto?> ObterPorEmail(string email);
    }
}
