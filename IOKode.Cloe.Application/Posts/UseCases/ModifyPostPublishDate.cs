using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Application.Posts.Repositories;
using IOKode.Cloe.Domain.Posts.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Posts.UseCases
{
    public class ModifyPostPublishDate
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ModifyPostPublishDate(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        /// <exception cref="KeyNotFoundException">Thrown when cannot found any post with the supplied id.</exception>
        public async Task InvokeAsync(Id<Post> postId, DateTime? publishDate, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IPostRepository>();
            var post = await repository.GetByIdAsync(postId, cancellationToken);

            if (post is null)
            {
                throw new KeyNotFoundException("Any post found with supplied id.");
            }
            
            post.PublishDate = publishDate;

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}