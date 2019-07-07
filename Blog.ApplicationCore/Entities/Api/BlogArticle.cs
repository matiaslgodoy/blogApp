using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class BlogArticle : BaseEntity
    {
        public BlogArticle() {
            Active = true;
            PublishedDate = DateTime.Now;
            BlogFollows = new HashSet<BlogFollow>();
            BlogLikes = new HashSet<BlogLike>();
            BlogTags = new HashSet<BlogTag>();
        }

        public Guid Id { get; set; }

        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
       
        public string TextContent { get; set; }

        public DateTime PublishedDate { get; set; }

        public bool Active { get; set; }

        [ForeignKey("StatusId")]
        public BlogStatus Status { get; set; }
        
        [ForeignKey("ImageId")]
        public Image Image { get; set; }

        [ForeignKey("UserId")]
        public User Author { get; set; }

        public Guid? ImageId { get; set; }
        [NotMapped]
        public bool DeleteImage { get; set; }

        [InverseProperty("Blog")]
        public ICollection<BlogFollow> BlogFollows { get; set; }
        [InverseProperty("Blog")]
        public ICollection<BlogLike> BlogLikes { get; set; }
        [InverseProperty("Blog")]
        public ICollection<BlogTag> BlogTags { get; set; }
        
    }
}
