using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Domain.Pages.Entities
{
    public class Page
    {
        public Id<Page>? Id { get; set; }
        public string Title { get; set; }
        public Markdown Content { get; set; }
    }
}