using BulutBlog.Data.Abstract;
using BulutBlog.Data.Concrete.EfCore;
using BulutBlog.Entity;

namespace BulutBlog.Data.Concrete
{

    public class EfBlogPostRepository : IBlogPostRepository
    {

        private BlogContext _context;

        public EfBlogPostRepository(BlogContext context){
            _context = context;
        }
        public IQueryable<BlogPost> BlogPosts => _context.BlogPosts;

        public void CreateBlogPost(BlogPost blogpost)
        {
            _context.BlogPosts.Add(blogpost);
            _context.SaveChanges();
        }
    }
}