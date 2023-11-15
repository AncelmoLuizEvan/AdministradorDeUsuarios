using Microsoft.EntityFrameworkCore;
using RpcCalc.Domain.Interfaces;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.RepositoriesReadOnly
{
    public class RepositoryReadOnly<T> : IRepositoryReadOnly<T> where T : class
    {
        protected readonly DataBaseContext _context;

        public RepositoryReadOnly(DataBaseContext context)
        {
            _context = context;
        }

        public virtual async Task<T?> Capturar(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>?> Listar()
        {
            IQueryable<T> query = _context.Set<T>();
            return await query.ToListAsync();
        }
    }
}
