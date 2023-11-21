namespace RpcCalc.Domain.Interfaces.UseCases.PermissaoUseCase
{
    public interface IPermissaoDelete
    {
        Task<bool> Execute(Guid id);
    }
}
