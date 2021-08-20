using System.Threading;
using System.Threading.Tasks;

namespace IOKode.Cloe.Application
{
    public interface IUnitOfWork
    {
        public TRepository GetRepository<TRepository>();
        public Task CommitAsync(CancellationToken cancellationToken);
    }
}