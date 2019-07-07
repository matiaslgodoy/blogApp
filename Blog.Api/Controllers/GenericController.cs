using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ApplicationCore.Services.Paging;
using Common.Generic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Controllers
{
    public class GenericController<T> : BaseController where T : class
    {
        protected IGenericService<T> genericService;

        public GenericController(IGenericService<T> genericService)
        {
            this.genericService = genericService;
        }

        [HttpGet("list")]
        public virtual async Task<ICollection<T>> Get()
        {
            return await this.genericService.List();
        }

        [HttpPost("paging")]
        public virtual async Task<PaginatorResponseModel<T>> Get([FromBody]BasePaginatorRequestModel paginatorRequestModel)
        {
            return await this.genericService.List(paginatorRequestModel);
        }

        [HttpGet("get/{id}")]
        public virtual async Task<T> Get(Guid id)
        {
            return await this.genericService.Get(id);
        }

        [HttpDelete("delete/{id}")]
        public virtual async Task Delete(Guid id)
        {
            await this.genericService.Delete(id);
        }

        [HttpPost("update")]
        public virtual async Task<T> Update([FromBody]T entity)
        {
            return await this.genericService.Update(entity);
        }

        [HttpPut("add")]
        public virtual async Task<T> Insert([FromBody]T entity)
        {
            return await this.genericService.Insert(entity);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.genericService.Dispose();
        }

    }
}
