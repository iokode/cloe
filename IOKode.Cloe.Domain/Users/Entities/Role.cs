using System.Collections.Generic;
using IOKode.Cloe.Domain.Users.ValueObject;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Domain.Users.Entities
{
    public class Role
    {
        public Id<Role> Id { get; set; }
        public string Name { get; set; }
        public IList<Permission> Permissions { get; } = new List<Permission>();
    }
}