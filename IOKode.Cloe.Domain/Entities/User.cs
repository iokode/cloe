namespace IOKode.Cloe.Domain.Entities
{
    public class User
    {
        public Id<User> Id { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
    }
}