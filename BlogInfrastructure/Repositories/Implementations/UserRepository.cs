using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Repositories.Interfaces;
using BlogInfrastructure.Data;
using Common.Generic.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogInfrastructure.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogApiContextRef blogApiContextRef) : base(blogApiContextRef)
        {
        }
    }
}
