using System.Linq;

namespace IOKode.Cloe.Application.PersistenceContracts
{
    public interface IQueryService
    {
        public IQueryable<TEntity> Query<TEntity>();
    }
}