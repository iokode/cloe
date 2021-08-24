using System.Collections.Generic;
using IOKode.Cloe.Domain.Authors.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Domain.Users.Entities
{
    public class User
    {
        public Id<User> Id { get; set; }
        public string Username { get; set; }
        public IList<Id<Role>> RoleIds { get; set; } = new List<Id<Role>>();
        public IList<Id<Author>> AuthorIds { get; set; } = new List<Id<Author>>();
    }
}