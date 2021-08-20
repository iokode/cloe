namespace IOKode.Cloe.Domain.Entities
{
    public class Page
    {
        public Id<Page> Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}