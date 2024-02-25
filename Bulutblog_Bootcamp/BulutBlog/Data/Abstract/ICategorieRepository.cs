using BulutBlog.Entity;

namespace BulutBlog.Data.Abstract
{
    public interface ICategorieRepository{
        IQueryable<Categorie> Categories {get;}

        void CreateCategorie(Categorie blogpost);
    }
}