using System;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Repositories;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;

namespace IOKode.Cloe.Application.Posts.UseCases
{
    public class ModifyPostPublishDate
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ModifyPostPublishDate(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(Id<Post> postId, DateTime? publishDate, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IPostRepository>();
            var post = await repository.GetByIdAsync(postId, cancellationToken);

            post.PublishDate = publishDate;

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}