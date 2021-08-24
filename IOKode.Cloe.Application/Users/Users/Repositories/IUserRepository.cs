using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Users.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Users.Users.Repositories
{
    public interface IUserRepository : IRepository
    {
        public Task AddAsync(User user, CancellationToken cancellationToken);
        public Task<User> GetByIdAsync(Id<User> userId, CancellationToken cancellationToken);
    }
}