using System.Data;

namespace RpcCalc.Domain.Interfaces
{
    public interface IDbSession : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; set; }
    }
}
