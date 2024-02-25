using BulutBlog.Entity;

namespace BulutBlog.Data.Abstract
{

    public interface ICommentRepository{
        IQueryable<Comment> Comments {get;}

        void CreateComments(Comment comment);
    }
}