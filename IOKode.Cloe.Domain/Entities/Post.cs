using System;
using System.Collections.Generic;

namespace IOKode.Cloe.Domain.Entities
{
    public class Post
    {
        public Id<Post> Id { get; set; }
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
        public string Content { get; set; } // todo Change type to Markdown
        public IList<string> Keywords { get; set; }
        public Id<User> AuthorId { get; set; }
    }
}