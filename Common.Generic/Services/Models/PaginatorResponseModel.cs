using System.Collections.Generic;

namespace Common.Generic.Services.Models
{
    public class PaginatorResponseModel<TMapper> where TMapper : class
    {

        public List<TMapper> ResultList { get; set; }

        public int TotalRows { get; set; }

        public PaginatorResponseModel()
        {
        }
    }
}
