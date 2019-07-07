using Blog.ApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Services.Paging
{
    public class BasePaginatorRequestModel : PaginatorRequestModel
    {
        public string Search { get; set; }

        public bool? Actives { get; set; }

        public int ActivesNumber { get; set; }

        public BasePaginatorRequestModel()
        {
        }
    }
}
