using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Authors.Repositories
{
    public interface IAuthorRepository : IRepository
    {
        public Task AddAsync(Author author, CancellationToken cancellationToken);
        public Task<Author> GetByIdAsync(Id<Author> author, CancellationToken cancellationToken);
    }
}