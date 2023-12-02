namespace RpcCalc.Domain.Interfaces.UseCases.PerfilUseCase
{
    public interface IPerfilDelete
    {
        Task<bool> Execute(Guid id);
    }
}
