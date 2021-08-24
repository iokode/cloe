using System.Collections.Generic;
using IOKode.Cloe.Application.Contracts.Persistence;

namespace IOKode.Cloe.InMemoryPersistence.Repositories
{
    internal interface IInMemoryRepository : IRepository
    {
        public void PersistItems();
    }

    internal abstract class InMemoryRepository<TEntity> : IInMemoryRepository
    {
        public List<TEntity> Items { get; } = new();
        public List<TEntity> PersistedItems { get; private set; } = new();

        public void PersistItems()
        {
            PersistedItems = Items;
        }
    }
}