using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Posts.Repositories
{
    public interface IPostRepository : IRepository
    {
        public Task AddAsync(Post post, CancellationToken cancellationToken);
        public Task<Post?> GetByIdAsync(Id<Post> id, CancellationToken cancellationToken);
        public Task DeleteAsync(Id<Post> id, CancellationToken cancellationToken);

        public async Task DeleteAsync(Post post, CancellationToken cancellationToken)
        {
            await DeleteAsync(post.Id, cancellationToken);
        }
    }
}