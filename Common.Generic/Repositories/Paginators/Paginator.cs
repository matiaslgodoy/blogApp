using System.Collections.Generic;

namespace Common.Generic.Repositories.Paginators
{
    public class Paginator<TEntity> where TEntity : class
    {
        public List<TEntity> Result { get; set; }

        public int TotalRow { get; set; }

        public Paginator()
        {
        }
    }
}
