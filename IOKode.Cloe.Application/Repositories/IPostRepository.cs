using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Repositories
{
    public interface IPostRepository
    {
        public Task AddAsync(Post post, CancellationToken cancellationToken);
        public Task<Post> GetByIdAsync(Id<Post> id, CancellationToken cancellationToken);
        public Task DeleteAsync(Id<Post> id, CancellationToken cancellationToken);

        public async Task DeleteAsync(Post post, CancellationToken cancellationToken)
        {
            await DeleteAsync(post.Id, cancellationToken);
        }
    }
}