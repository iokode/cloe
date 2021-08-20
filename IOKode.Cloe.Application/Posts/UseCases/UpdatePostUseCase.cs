using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Posts.Models;
using IOKode.Cloe.Application.Repositories;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Posts.UseCases
{
    public class UpdatePostUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UpdatePostUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(Id<Post> id, UpdatePostModel model, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IPostRepository>();
            var post = await repository.GetByIdAsync(id, cancellationToken);

            post.Title = model.Title;
            post.SearcherTitle = model.SearcherTitle;
            post.SearcherDescription = model.SearcherDescription;
            post.Content = model.Content;
            post.PublishDate = model.PublishDate;
            post.UpdateDate = DateTime.Now;
            post.Keywords = model.Keywords.ToList();

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}