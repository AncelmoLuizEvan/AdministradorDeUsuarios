namespace RpcCalc.Domain.Interfaces.UseCases.UsuarioUseCase
{
    public interface IUsuarioDelete
    {
        Task<bool> Execute(Guid id);
        Task<bool> Execute(Guid id, Guid idrole);
        Task<bool> Execute(Guid id, Guid idperfil, Guid? idpermissao);
    }
}
