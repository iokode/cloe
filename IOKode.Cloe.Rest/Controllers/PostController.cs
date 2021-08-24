using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Application.Posts.Models;
using IOKode.Cloe.Application.Posts.UseCases;
using IOKode.Cloe.Domain.Posts.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IOKode.Cloe.Rest.Controllers
{
    [Route("api/posts")]
    public class PostController : Controller
    {
        [HttpGet] // "api/post"
        public async Task<IActionResult> GetPostsAsync(
            [FromServices] IQueryService queryService,
            CancellationToken cancellationToken)
        {
            var posts = queryService.Query<Post>()
                .Select(post => new
                {
                    post.Title,
                    post.Content,
                    post.CreationDate
                })
                .ToArray();

            return Ok(posts);
        }

        [HttpGet("id")] // "api/post/5" 
        public async Task<IActionResult> GetPostByIdAsync(
            [FromServices] IQueryService queryService,
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var post = queryService.Query<Post>()
                .Where(post => post.Id.Value == id)
                .Select(post => new
                {
                    post.Title,
                    post.Content,
                    post.CreationDate
                })
                .FirstOrDefault();

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePostAsync(
            [FromServices] CreatePostUseCase useCase,
            [FromBody] CreatePostModel model,
            CancellationToken cancellationToken)
        {
            await useCase.InvokeAsync(model, cancellationToken);
            return NoContent();
        }
    }
}