using System;
using System.Linq;
using IOKode.Cloe.Application;
using IOKode.Cloe.Domain.Entities;
using IOKode.Cloe.InMemoryPersistence.Repositories;

namespace IOKode.Cloe.InMemoryPersistence
{
    internal class InMemoryQueryService : IQueryService
    {
        public IQueryable<TEntity> Query<TEntity>()
        {
            if (typeof(TEntity).IsAssignableTo(typeof(Post)))
            {
                var repository =
                    (InMemoryPostRepository) InMemoryUnitOfWork.GetInMemoryRepository<InMemoryPostRepository>();
                return (IQueryable<TEntity>) repository.PersistedItems.AsQueryable();
            }

            throw new InvalidOperationException("Trying to query a not registered entity.");
        }
    }
}