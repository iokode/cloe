using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Posts.Entities;
using IOKode.Cloe.Domain.ValueObjects;

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