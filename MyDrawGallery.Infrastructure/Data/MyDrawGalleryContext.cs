using Microsoft.EntityFrameworkCore;
using MyDrawGallery.Core.Entitites;
using System.Reflection;

namespace MyDrawGallery.Infrastructure.Data
{
    public partial class MyDrawGalleryContext : DbContext
    {
        public MyDrawGalleryContext()
        {
        }

        public MyDrawGalleryContext(DbContextOptions<MyDrawGalleryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
