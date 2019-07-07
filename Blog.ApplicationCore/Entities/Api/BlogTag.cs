using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class BlogTag : BaseEntity
    {
        public BlogTag() {
        }

        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
