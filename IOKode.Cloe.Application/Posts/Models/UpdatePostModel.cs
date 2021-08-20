using System;
using System.Collections.Generic;

namespace IOKode.Cloe.Application.Posts.Models
{
    public record UpdatePostModel
    {
        public string Title { get; set; }
        public string SearcherTitle { get; set; }
        public string SearcherDescription { get; set; }
        public string Content { get; set; }
        public DateTime? PublishDate { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }
}