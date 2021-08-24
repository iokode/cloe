using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Authors.Repositories;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Application.Users.Users.Models;
using IOKode.Cloe.Application.Users.Users.Repositories;
using IOKode.Cloe.Domain.Authors.Entities;
using IOKode.Cloe.Domain.Users.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Users.Users.UseCases
{
    public class CreateUserUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IQueryService _QueryService;

        public CreateUserUseCase(IUnitOfWork unitOfWork, IQueryService queryService)
        {
            _UnitOfWork = unitOfWork;
            _QueryService = queryService;
        }

        public async Task InvokeAsync(CreateUserModel model, CancellationToken cancellationToken)
        {
            var author = new Author
            {
                Name = model.AuthorName
            };

            var authorRepository = _UnitOfWork.GetRepository<IAuthorRepository>();
            await authorRepository.AddAsync(author, cancellationToken);

            var user = new User
            {
                Username = model.Username,
                AuthorIds = {author.Id!},
                RoleIds = {await _GetRoleIdAsync(model.RoleName)}
            };

            var userRepository = _UnitOfWork.GetRepository<IUserRepository>();
            await userRepository.AddAsync(user, cancellationToken);

            await _UnitOfWork.CommitAsync(cancellationToken);
        }

        private async Task<Id<Role>> _GetRoleIdAsync(string roleName)
        {
            var query = _QueryService.Query<Role>()
                .Where(role => role.Name == roleName)
                .Select(role => role.Id);

            return query.First();
        }
    }
}