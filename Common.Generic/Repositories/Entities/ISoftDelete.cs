using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Generic.Repositories.Entities
{
    public interface ISoftDelete
    {
        bool? IsDeleted { get; set; }
    }
}
