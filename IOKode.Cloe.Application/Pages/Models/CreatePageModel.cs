using System.ComponentModel.DataAnnotations;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Pages.Models
{
    public class CreatePageModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public Markdown Content { get; set; }
    }
}