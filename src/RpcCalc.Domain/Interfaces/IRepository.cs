namespace RpcCalc.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task Gravar(T entity);
        Task Alterar(T entity);
        Task Excluir(T entity);
    }
}
