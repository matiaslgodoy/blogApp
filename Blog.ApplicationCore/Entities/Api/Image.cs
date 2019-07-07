using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class Image : BaseEntity
    {
        public Image() {
        }

        public Guid Id { get; set; }
        [StringLength(2048)]

        public string Url { get; set; }

        public Guid ImageTypeId { get; set; }

        [ForeignKey("ImageTypeId")]
        public ImageType ImageType { get; set; }
    }
}
