using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.PersistenceContracts;
using IOKode.Cloe.Application.Posts.Models;
using IOKode.Cloe.Application.Posts.Repositories;
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

        /// <exception cref="KeyNotFoundException">Thrown when cannot found any post with the supplied id.</exception>
        public async Task InvokeAsync(Id<Post> id, UpdatePostModel model, CancellationToken cancellationToken)
        {
            var repository = _UnitOfWork.GetRepository<IPostRepository>();
            var post = await repository.GetByIdAsync(id, cancellationToken);

            if (post is null)
            {
                throw new KeyNotFoundException("Any post found with supplied id.");
            }

            if (model.Title is not null)
            {
                post.Title = model.Title;
            }

            if (model.SearcherTitle is not null)
            {
                post.SearcherTitle = model.SearcherTitle;
            }

            if (model.SearcherDescription is not null)
            {
                post.SearcherDescription = model.SearcherDescription;
            }

            if (model.Content is not null)
            {
                post.Content = model.Content;
            }

            post.PublishDate = model.PublishDate;
            post.UpdateDate = DateTime.Now;
            
            if (model.Keywords is not null)
            {
                post.Keywords = model.Keywords.ToList();
            }

            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}