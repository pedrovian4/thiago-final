using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace upload_img.Model
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<PostTag>().HasOne(x => x.Posts).WithOne();
            builder.Entity<Tag>().HasOne(x => x.PostTag).WithOne(x => x.Tags);

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostTag> PostTags{ get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
