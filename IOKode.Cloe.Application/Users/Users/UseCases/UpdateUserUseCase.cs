using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IOKode.Cloe.Application.Contracts.Persistence;
using IOKode.Cloe.Application.Users.Users.Models;
using IOKode.Cloe.Application.Users.Users.Repositories;
using IOKode.Cloe.Domain.Users.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Users.Users.UseCases
{
    public class UpdateUserUseCase
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IQueryService _QueryService;

        public UpdateUserUseCase(IUnitOfWork unitOfWork, IQueryService queryService)
        {
            _UnitOfWork = unitOfWork;
            _QueryService = queryService;
        }

        public async Task InvokeAsync(Id<User> userId, UpdateUserModel model, CancellationToken cancellationToken)
        {
            var userRepository = _UnitOfWork.GetRepository<IUserRepository>();
            var user = await userRepository.GetByIdAsync(userId, cancellationToken);

            if (!string.IsNullOrWhiteSpace(model.Username))
            {
                user.Username = model.Username;
            }

            if (model.AuthorIds is not null)
            {
                user.AuthorIds = model.AuthorIds.ToList();
            }

            if (model.RoleNames is not null)
            {
                user.RoleIds = (await _GetRoleIds(model.RoleNames, cancellationToken)).ToList();
            }

            await _UnitOfWork.CommitAsync(cancellationToken);
        }

        private async Task<IEnumerable<Id<Role>>> _GetRoleIds(IEnumerable<string> roleNames,
            CancellationToken cancellationToken)
        {
            var query =
                from role in _QueryService.Query<Role>()
                where roleNames.Contains(role.Name)
                select role.Id;

            return query.ToArray();
        }
    }
}