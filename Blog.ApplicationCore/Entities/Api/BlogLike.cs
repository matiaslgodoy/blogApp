using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class BlogLike : BaseEntity
    {
        public BlogLike() {
        }

        public Guid BlogId { get; set; }
        public Guid UserId { get; set; }
        public bool Like { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
