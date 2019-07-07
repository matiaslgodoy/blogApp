using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
        }

        public DateTime CreatedDate { get; set; }
        public Guid? CreatedUser { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public Guid? LastModifiedUser { get; set; }
        public string LastModifiedUserEmail { get; set; }

    }
}
