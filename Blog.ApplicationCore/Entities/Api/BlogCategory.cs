using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class BlogCategory : BaseEntity
    {
        public BlogCategory() {
        }

        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Order { get; set; }
    }
}
