using System.Collections.Generic;
using IOKode.Cloe.Domain.Authors.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Users.Users.Models
{
    public class UpdateUserModel
    {
        public string? Username { get; init; }
        public IEnumerable<Id<Author>>? AuthorIds { get; init; }
        public IEnumerable<string>? RoleNames { get; init; }
    }
}