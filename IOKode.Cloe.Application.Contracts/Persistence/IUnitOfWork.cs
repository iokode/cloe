using System.Threading;
using System.Threading.Tasks;

namespace IOKode.Cloe.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public TRepository GetRepository<TRepository>() where TRepository : IRepository;
        public Task CommitAsync(CancellationToken cancellationToken);
    }
}