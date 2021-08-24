using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Application.Posts.Repositories;
using IOKode.Cloe.InMemoryPersistence.Repositories;

namespace IOKode.Cloe.InMemoryPersistence
{
    internal class InMemoryUnitOfWork : IUnitOfWork
    {
        public static List<IInMemoryRepository> Repositories { get; } = new()
        {
            new InMemoryPostRepository()
        };

        public TRepository GetRepository<TRepository>() where TRepository : IRepository
        {
            if (typeof(TRepository).IsAssignableTo(typeof(IPostRepository)))
            {
                return (TRepository) GetInMemoryRepository<InMemoryPostRepository>();
            }

            throw new Exception("Trying to get not implemented repository.");
        }

        public Task CommitAsync(CancellationToken cancellationToken)
        {
            foreach (var repository in Repositories)
            {
                repository.PersistItems();
            }

            return Task.CompletedTask;
        }

        public static IRepository GetInMemoryRepository<TRepository>()
            where TRepository : IInMemoryRepository, new()
        {
            return Repositories.First(repository => repository is TRepository);
        }
    }
}