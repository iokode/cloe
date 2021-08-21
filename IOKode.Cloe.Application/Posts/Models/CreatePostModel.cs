using System;
using System.Collections.Generic;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Posts.Models
{
    public record CreatePostModel
    {
        public Id<User> AuthorId { get; set; }
        public string Title { get; set; }
        public string SearcherTitle { get; set; }
        public string SearcherDescription { get; set; }
        public Markdown Content { get; set; }
        public DateTime? PublishDate { get; set; }
        public IEnumerable<string> Keywords { get; set; }
    }
}