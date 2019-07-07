using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Extensions;
using Blog.ApplicationCore.Repositories.Interfaces;
using Blog.ApplicationCore.Services.Paging;
using BlogInfrastructure.Data;
using Common.Generic.Repositories;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogInfrastructure.Repositories.Implementations
{
    public class BlogArticleRepository : GenericRepository<BlogArticle>, IBlogArticleRepository
    {
        public BlogArticleRepository(BlogApiContextRef blogApiContextRef) : base(blogApiContextRef)
        {
        }

        public Task<PaginatorResponseModel<BlogArticle>> GetArticlesByName(BasePaginatorRequestModel requestModel)
        {
            throw new NotImplementedException();
        }

        public Task<BlogArticle> GetPublicArticle(Guid articleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<IGrouping<BlogCategory, BlogArticle>>> GetPublicViewArticles()
        {
            throw new NotImplementedException();
        }
    }
}
