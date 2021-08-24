using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Authors.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Authors.Repositories
{
    public interface IAuthorRepository : IRepository
    {
        public Task AddAsync(Author author, CancellationToken cancellationToken);
        public Task<Author> GetByIdAsync(Id<Author> author, CancellationToken cancellationToken);
    }
}