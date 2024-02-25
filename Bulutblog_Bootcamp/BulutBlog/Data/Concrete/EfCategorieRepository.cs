using BulutBlog.Data.Abstract;
using BulutBlog.Data.Concrete.EfCore;
using BulutBlog.Entity;

namespace BulutBlog.Data.Concrete
{
    public class EfCategorieRepository : ICategorieRepository
    {
        private BlogContext _context;

        public EfCategorieRepository(BlogContext context){
            _context= context;
        }
        public IQueryable<Categorie> Categories => _context.Categories;

        public void CreateCategorie(Categorie blogpost)
        {
            _context.Categories.Add(blogpost);
            _context.SaveChanges();
        }
    }
}