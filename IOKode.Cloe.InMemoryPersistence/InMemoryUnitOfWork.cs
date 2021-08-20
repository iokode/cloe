using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application;

namespace IOKode.Cloe.InMemoryPersistence
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        public TRepository GetRepository<TRepository>()
        {
            throw new System.NotImplementedException();
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}