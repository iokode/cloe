using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Authors.Repositories;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Domain.Authors.Entities;

namespace IOKode.Cloe.Application.Authors.UseCases
{
    public class CreateAuthorUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CreateAuthorUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(string name, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = name
            };

            var repository = _UnitOfWork.GetRepository<IAuthorRepository>();
            await repository.AddAsync(author, cancellationToken);
            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}