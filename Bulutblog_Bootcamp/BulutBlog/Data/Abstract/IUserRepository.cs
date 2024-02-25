using BulutBlog.Entity;

namespace BulutBlog.Data.Abstract
{
    public interface IUserRepository{

        IQueryable<User> Users {get;}

        void CreateUser(User user);
    }
}