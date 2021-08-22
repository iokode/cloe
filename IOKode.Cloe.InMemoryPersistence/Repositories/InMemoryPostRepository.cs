using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Posts.Repositories;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.InMemoryPersistence.Repositories
{
    internal class InMemoryPostRepository : InMemoryRepository<Post>, IPostRepository
    {
        public Task AddAsync(Post post, CancellationToken cancellationToken)
        {
            var lastId = !Items.Any() ? 0 : Items.Max(post => int.Parse(post.Id.Value));
            post.Id = new Id<Post>((lastId + 1).ToString());
            Items.Add(post);
            return Task.CompletedTask;
        }

        public Task<Post?> GetByIdAsync(Id<Post> id, CancellationToken cancellationToken)
        {
            var post = PersistedItems.FirstOrDefault(post => post.Id == id);
            return Task.FromResult(post);
        }

        public async Task DeleteAsync(Id<Post> id, CancellationToken cancellationToken)
        {
            var post = await GetByIdAsync(id, cancellationToken);

            if (post is null)
            {
                return;
            }

            Items.Remove(post);
            PersistedItems.Remove(post);
        }
    }
}