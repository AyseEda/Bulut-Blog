using BulutBlog.Entity;
using Microsoft.EntityFrameworkCore;

namespace BulutBlog.Data.Concrete.EfCore
{
    public class BlogContext : DbContext
    {
        public BlogContext (DbContextOptions<BlogContext>options):base(options)
        {}

        public DbSet<BlogPost>BlogPosts => Set<BlogPost>();
        public DbSet<Comment>Comments => Set<Comment>();
        public DbSet<Categorie>Categories => Set<Categorie>();
        public DbSet<User>Users => Set<User>();

    }
}