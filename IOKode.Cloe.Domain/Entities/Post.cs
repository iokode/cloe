using System;
using System.Collections.Generic;
using IOKode.Cloe.Domain.ValueObjects;

namespace IOKode.Cloe.Domain.Entities
{
    public class Post
    {
        public Id<Post>? Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? PublishDate { get; set; }

        public bool IsPublished
        {
            get
            {
                if (!PublishDate.HasValue)
                {
                    return false;
                }

                return PublishDate <= DateTime.Now;
            }
        }

        public string Title { get; set; }
        public string SearcherTitle { get; set; }
        public string SearcherDescription { get; set; }
        public Markdown Content { get; set; }
        public IList<string> Keywords { get; set; }
        public Id<Author> AuthorId { get; set; }

        public void Publish(DateTime publishDate)
        {
            PublishDate = publishDate;
        }
        
        public void Publish() => Publish(DateTime.Now);
    }
}