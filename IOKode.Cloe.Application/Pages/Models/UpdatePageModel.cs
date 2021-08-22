using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Pages.Models
{
    public class UpdatePageModel
    {
        public string? Title { get; set; }
        public Markdown? Content { get; set; }
    }
}