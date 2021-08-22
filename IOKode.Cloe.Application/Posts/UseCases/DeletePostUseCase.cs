using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Application.Posts.Repositories;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Posts.UseCases
{
    public class DeletePostUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public DeletePostUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(Id<Post> id, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IPostRepository>();
            await repository.DeleteAsync(id, cancellationToken);

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}