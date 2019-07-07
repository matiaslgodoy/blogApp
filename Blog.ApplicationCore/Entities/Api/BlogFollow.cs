using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class BlogFollow : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }

        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
