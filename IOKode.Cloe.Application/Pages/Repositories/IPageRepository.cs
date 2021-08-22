using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Pages.Repositories
{
    public interface IPageRepository : IRepository
    {
        public Task AddAsync(Page page, CancellationToken cancellationToken);
        public Task<Page?> GetByIdAsync(Id<Page> pageId, CancellationToken cancellationToken);
    }
}