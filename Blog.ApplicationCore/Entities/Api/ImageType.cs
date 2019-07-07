using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.ApplicationCore.Entities.Api
{
    public class ImageType : BaseEntity
    {
        public ImageType(){
        }

        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double MinHeight { get; set; }

        public double MinWidth { get; set; }

        public double Size { get; set; }
    }
}
