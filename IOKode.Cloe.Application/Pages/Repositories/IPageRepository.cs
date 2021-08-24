using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Pages.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Pages.Repositories
{
    public interface IPageRepository : IRepository
    {
        public Task AddAsync(Page page, CancellationToken cancellationToken);
        public Task<Page?> GetByIdAsync(Id<Page> pageId, CancellationToken cancellationToken);
    }
}