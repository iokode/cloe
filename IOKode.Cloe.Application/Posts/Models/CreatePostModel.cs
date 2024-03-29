using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IOKode.Cloe.Domain;
using IOKode.Cloe.Domain.Authors.Entities;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Application.Posts.Models
{
    public record CreatePostModel
    {
        [Required]
        public Id<Author> AuthorId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? SearcherTitle { get; set; }
        public string? SearcherDescription { get; set; }

        [Required]
        public Markdown Content { get; set; }

        public DateTime? PublishDate { get; set; }
        public IEnumerable<string>? Keywords { get; set; }
    }
}