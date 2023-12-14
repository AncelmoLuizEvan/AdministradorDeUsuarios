using MySql.Data.MySqlClient;
using RpcCalc.Domain.Interfaces;
using System.Data;

namespace RpcCalc.Infra.Context
{
    public sealed class DbSession : IDbSession
    {
        private Guid _id;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DbSession(string connectionString)
        {
            _id = Guid.NewGuid();
            Connection = new MySqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose() => Connection?.Dispose();
    }
}
