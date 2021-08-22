using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Pages.Models;
using IOKode.Cloe.Application.Pages.Repositories;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Pages.UseCases
{
    public class CreatePageUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CreatePageUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }
        
        public async Task InvokeAsync(CreatePageModel model, CancellationToken cancellationToken)
        {
            var page = new Page
            {
                Title = model.Title,
                Content = model.Content
            };

            var repository = _UnitOfWork.GetRepository<IPageRepository>();
            await repository.AddAsync(page, cancellationToken);

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}