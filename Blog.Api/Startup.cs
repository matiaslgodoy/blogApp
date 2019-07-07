using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Blog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //Services
            services.AddScoped<ApplicationCore.Services.Interfaces.IBlogArticleService, ApplicationCore.Services.Implementations.BlogArticleService>();
            services.AddScoped<ApplicationCore.Services.Interfaces.IUserService, ApplicationCore.Services.Implementations.UserService>();

            //Repositories
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IBlogArticleRepository, BlogInfrastructure.Repositories.Implementations.BlogArticleRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IBlogCategoryRepository, BlogInfrastructure.Repositories.Implementations.BlogCategoryRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IBlogStatusRepository, BlogInfrastructure.Repositories.Implementations.BlogStatusRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IBlogTagRepository, BlogInfrastructure.Repositories.Implementations.BlogTagRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IBlogFollowRepository, BlogInfrastructure.Repositories.Implementations.BlogFollowRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IBlogLikeRepository, BlogInfrastructure.Repositories.Implementations.BlogLikeRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IImageRepository, BlogInfrastructure.Repositories.Implementations.ImageRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IImageTypeRepository, BlogInfrastructure.Repositories.Implementations.ImageTypeRepository>();
            services.AddScoped<ApplicationCore.Repositories.Interfaces.IUserRepository, BlogInfrastructure.Repositories.Implementations.UserRepository>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
