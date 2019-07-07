using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Repositories.Interfaces;
using Blog.ApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.ApplicationCore.Services.Implementations
{
    public class UserService : GenericService<User>, IUserService
    {
        readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            this.userRepository = userRepository;
        }

    }
}
