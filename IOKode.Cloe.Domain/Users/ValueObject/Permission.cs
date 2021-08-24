namespace IOKode.Cloe.Domain.Users.ValueObject
{
    public record Permission
    {
        public string Name { get; }

        public Permission(string name)
        {
            Name = name;
        }
    }
}