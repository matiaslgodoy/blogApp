using Blog.ApplicationCore.Entities;
using Blog.ApplicationCore.Entities.Api;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogInfrastructure.Data
{
    public partial class BlogApiContextRef : DbContext
    {
        public BlogApiContextRef()
        {
        }

        public BlogApiContextRef(DbContextOptions<BlogApiContextRef> options)
            : base(options) {
        }

        public virtual DbSet<BlogArticle> BlogArticles { get; set; }
        public virtual DbSet<BlogCategory> BlogCategories { get; set; }
        public virtual DbSet<BlogTag> BlogTags { get; set; }
        public virtual DbSet<BlogStatus> BlogStatus { get; set; }
        public virtual DbSet<BlogLike> BlogLikes { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ImageType> ImageTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server= ;Initial Catalog=BlogApiDev;Persist Security Info=False;User ID=root;Password=root;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Ref");
           
        }

        public override int SaveChanges()
        {
            AddModificationTime();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddModificationTime();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddModificationTime()
        {
            try
            {
                var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
                if (entities.Count() == 0)
                {
                    return;
                }
                var slot = System.Threading.Thread.GetNamedDataSlot("userdata.userName");
                var currentUsername = "";
                if (slot != null)
                {
                    var username = System.Threading.Thread.GetData(slot);
                    if (username != null)
                    {
                        currentUsername = username.ToString();
                    }
                }
                foreach (var entity in entities)
                {
                    ((BaseEntity)entity.Entity).LastModifiedDate = DateTime.UtcNow;
                    if (!string.IsNullOrEmpty(currentUsername))
                    {
                        ((BaseEntity)entity.Entity).LastModifiedUserEmail = currentUsername;
                    }

                }
            }
            catch (Exception ex)
            {

            }

        }

    }
}
