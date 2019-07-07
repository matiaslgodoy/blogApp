using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Services.Interfaces
{
    public class PaginatorRequestModel
    {
        public int RowsPage { get; set; }

        public int Page { get; set; }

        public string OrderProperty { get; set; }

        public bool Desc { get; set; }

        public List<SearchFieldRequestModel> SearchFieldRequestModels { get; set; }

        public PaginatorRequestModel()
        {
        }
    }

    public class SearchFieldRequestModel
    {
        public string Field { get; set; }

        public object Value { get; set; }
    }
}
