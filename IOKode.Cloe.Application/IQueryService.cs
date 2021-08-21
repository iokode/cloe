using System.Linq;

namespace IOKode.Cloe.Application
{
    public interface IQueryService
    {
        public IQueryable<TEntity> Query<TEntity>();
    }
}