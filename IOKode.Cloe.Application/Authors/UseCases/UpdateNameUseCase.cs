using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Authors.Repositories;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Authors.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Authors.UseCases
{
    public class UpdateNameUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UpdateNameUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(Id<Author> authorId, string name, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IAuthorRepository>();
            var author = await repository.GetByIdAsync(authorId, cancellationToken);

            author.Name = name;
            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}