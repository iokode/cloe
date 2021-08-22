using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Pages.Models;
using IOKode.Cloe.Application.Pages.Repositories;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Pages.UseCases
{
    public class UpdatePageUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UpdatePageUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        /// <exception cref="KeyNotFoundException">Thrown when cannot found any page with the supplied id.</exception>
        public async Task InvokeAsync(Id<Page> pageId, UpdatePageModel model, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IPageRepository>();
            var page = await repository.GetByIdAsync(pageId, cancellationToken);

            if (page is null)
            {
                throw new KeyNotFoundException("Any page found with supplied id.");
            }

            if (model.Content is not null)
            {
                page.Content = model.Content;
            }

            if (model.Title is not null)
            {
                page.Title = model.Title;
            }

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}