using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Services.Interfaces;
using Blog.ApplicationCore.Services.Paging;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Blog.Api.Controllers
{   
    public class BlogArticleController : GenericController<BlogArticle>
    {
        readonly IBlogArticleService blogArticleService;

        public BlogArticleController(IBlogArticleService blogArticleService) : base(blogArticleService)
        {
            this.blogArticleService = blogArticleService;
        }

        public override async Task<PaginatorResponseModel<BlogArticle>> Get([FromBody] BasePaginatorRequestModel paginatorRequestModel)
        {
            return await this.blogArticleService.GetArticlesByName(paginatorRequestModel);
        }

        [HttpPost("saveorupdate")]
        public async Task<BlogArticle> SaveOrUpdate([FromForm]string articleJson)
        {
            var article = JsonConvert.DeserializeObject<BlogArticle>(articleJson, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            
            return await this.blogArticleService.SaveOrUpdate(article);
        }
    }
}
