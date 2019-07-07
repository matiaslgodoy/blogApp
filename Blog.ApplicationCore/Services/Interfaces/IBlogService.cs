using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Services.Paging;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Services.Interfaces
{
    public interface IBlogArticleService : IGenericService<BlogArticle>
    {
        Task<BlogArticle> SaveOrUpdate(BlogArticle article);

        Task<PaginatorResponseModel<BlogArticle>> GetArticlesByName(BasePaginatorRequestModel requestModel);

    }
}
