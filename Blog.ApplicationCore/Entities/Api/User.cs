using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class User : BaseEntity
    {
        public User() {
        }

        public Guid Id { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Surname { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }

        [ForeignKey("ImageId")]
        public Image ProfileImage { get; set; }

        [NotMapped]
        public ICollection<ContentFollow> ContentFollows { get; set; }

    }
}
