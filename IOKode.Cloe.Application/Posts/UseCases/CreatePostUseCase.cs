using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Application.Posts.Models;
using IOKode.Cloe.Application.Posts.Repositories;
using IOKode.Cloe.Domain.Posts.Entities;

namespace IOKode.Cloe.Application.Posts.UseCases
{
    public class CreatePostUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;

        public CreatePostUseCase(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task InvokeAsync(CreatePostModel model, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                CreationDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Title = model.Title,
                SearcherTitle = model.SearcherTitle,
                SearcherDescription = model.SearcherDescription,
                Content = model.Content,
                Keywords = model.Keywords.ToList(),
                PublishDate = model.PublishDate,
                AuthorId = model.AuthorId
            };

            var repository = _UnitOfWork.GetRepository<IPostRepository>();
            await repository.AddAsync(post, cancellationToken);
            await _UnitOfWork.CommitAsync(cancellationToken);
        }
    }
}