using BulutBlog.Data.Abstract;
using BulutBlog.Data.Concrete.EfCore;
using BulutBlog.Entity;

namespace BulutBlog.Data.Concrete
{

    public class EfCommentsRepository : ICommentRepository
    {
        private BlogContext _context;

        public EfCommentsRepository(BlogContext context){
            _context= context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        public void CreateComments(Comment comments)
        {
            _context.Comments.Add(comments);
            _context.SaveChanges();
        }
    }
}