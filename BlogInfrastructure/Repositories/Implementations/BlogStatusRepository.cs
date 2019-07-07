using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Repositories.Interfaces;
using BlogInfrastructure.Data;
using Common.Generic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogInfrastructure.Repositories.Implementations
{
    public class BlogStatusRepository : GenericRepository<BlogStatus>, IBlogStatusRepository
    {
        public BlogStatusRepository(BlogApiContextRef blogApiContextRef) : base(blogApiContextRef)
        {
        }
    }
}
