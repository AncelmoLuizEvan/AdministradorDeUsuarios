namespace RpcCalc.Domain.Interfaces
{
    public interface IRepositoryReadOnly<T> where T : class
    {
        Task<T?> Capturar(Guid id);
        Task<IEnumerable<T>?> Listar();
    }
}
