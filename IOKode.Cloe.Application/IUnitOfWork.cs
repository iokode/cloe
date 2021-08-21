using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Repositories;

namespace IOKode.Cloe.Application
{
    public interface IUnitOfWork
    {
        public TRepository GetRepository<TRepository>() where TRepository : IRepository;
        public Task CommitAsync(CancellationToken cancellationToken);
    }
}