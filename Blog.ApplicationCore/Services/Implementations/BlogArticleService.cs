using Blog.ApplicationCore.Entities.Api;
using Blog.ApplicationCore.Repositories.Interfaces;
using Blog.ApplicationCore.Services.Interfaces;
using Blog.ApplicationCore.Services.Paging;
using Common.Generic.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.ApplicationCore.Services.Implementations
{
    public class BlogArticleService : GenericService<BlogArticle>, IBlogArticleService
    {
        readonly IBlogArticleRepository blogArticleRepository;
        readonly IBlogStatusRepository blogStatusRepository;
        readonly IBlogCategoryRepository blogCategoryRepository;
        readonly IBlogLikeRepository blogLikeRepository;
        readonly IImageService imageService;
        readonly IImageTypeRepository imageTypeRepository;
        readonly IUserService userService;

        public BlogArticleService(IBlogArticleRepository blogArticleRepository,
                    IBlogStatusRepository blogStatusRepository,
                    IBlogCategoryRepository blogCategoryRepository,
                    IBlogLikeRepository blogLikeRepository,
                    IImageService imageService,
                    IImageTypeRepository imageTypeRepository,
                    IUserService userService) : base(blogArticleRepository) {
            this.blogArticleRepository = blogArticleRepository;
            this.blogStatusRepository = blogStatusRepository;
            this.blogCategoryRepository = blogCategoryRepository;
            this.blogLikeRepository = blogLikeRepository;
            this.imageService = imageService;
            this.imageTypeRepository = imageTypeRepository;
            this.userService = userService;

        }

        public async Task<PaginatorResponseModel<BlogArticle>> GetArticlesByName(BasePaginatorRequestModel requestModel)
        {
            return await this.blogArticleRepository.GetArticlesByName(requestModel);

        }

        public async Task<BlogArticle> SaveOrUpdate(BlogArticle blogArticle)
        {
            blogArticle = await DeleteArticleImage(blogArticle);

            List<ImageType> imageTypes = await this.imageTypeRepository.List();
           
            try
            {
                if (blogArticle.Id.Equals(Guid.Empty))
                {
                    blogArticle = await this.blogArticleRepository.Insert(blogArticle);
                }
                else
                {
                    blogArticle = await this.blogArticleRepository.Update(blogArticle);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return blogArticle;

        }


        private async Task<BlogArticle> DeleteArticleImage(BlogArticle blogArticle)
        {
            if (blogArticle.DeleteImage)
            {
                if (blogArticle.ImageId != null && !blogArticle.ImageId.Equals(Guid.Empty))
                {
                    var image = await this.imageService.Get(blogArticle.ImageId);
                    //await this.DeleteImage(image);
                    blogArticle.ImageId = null;
                    blogArticle.Image = null;
                }
            }
            
            return blogArticle;
        }


        public override void Dispose(bool disposer)
        {
            base.Dispose(disposer);
            if (disposer)
            {
                this.blogArticleRepository.Dispose();
                this.blogStatusRepository.Dispose();
                this.blogCategoryRepository.Dispose();
                this.blogLikeRepository.Dispose();
                this.imageService.Dispose();
                this.imageTypeRepository.Dispose();
                this.userService.Dispose();

            }
        }

    }
}
