using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Services.Paging;
using Common.Generic.Repositories;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Repositories.Interfaces
{
    public interface IBlogArticleRepository : IGenericRepository<BlogArticle>
    {
        Task<PaginatorResponseModel<BlogArticle>> GetArticlesByName(BasePaginatorRequestModel requestModel);
        
        Task<List<IGrouping<BlogCategory, BlogArticle>>> GetPublicViewArticles();

        Task<BlogArticle> GetPublicArticle(Guid articleId);
    }
}
