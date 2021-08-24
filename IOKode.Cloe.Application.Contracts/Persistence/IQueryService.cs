using System.Linq;

namespace IOKode.Cloe.Application.Contracts.Persistence
{
    public interface IQueryService
    {
        public IQueryable<TEntity> Query<TEntity>();
    }
}