using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Users.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Users.Users.Repositories
{
    public interface IRoleRepository : IRepository
    {
        public Task AddAsync(Role role, bool isDefault, CancellationToken cancellationToken);
        public Task<Role> GetByIdAsync(Id<Role> roleId, CancellationToken cancellationToken);
        public Task<Role> GetByNameAsync(string roleName, CancellationToken cancellationToken);
        public Task<Role> GetDefaultAsync(CancellationToken cancellationToken);
    }
}