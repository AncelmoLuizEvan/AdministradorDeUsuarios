using RpcCalc.Domain.Interfaces;
using RpcCalc.Infra.Context;

namespace RpcCalc.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataBaseContext _context;

        public Repository(DataBaseContext context)
        {
            _context = context;
        }

        public async Task Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Gravar(T entity)
        {
            _context.Set<T>().AddRange(entity);
            await _context.SaveChangesAsync();
        }
    }
}
