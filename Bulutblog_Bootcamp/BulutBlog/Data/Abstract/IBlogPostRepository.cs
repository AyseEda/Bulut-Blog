using BulutBlog.Entity;

namespace BulutBlog.Data.Abstract
{

    public interface IBlogPostRepository{

        IQueryable<BlogPost> BlogPosts {get;}

        void CreateBlogPost(BlogPost blogpost);
    }
}