using BulutBlog.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BulutBlog.ViewComponents
{
    public class CategoriesMenu: ViewComponent
    {
        private ICategorieRepository _categorieRepository;
        public CategoriesMenu(ICategorieRepository categorieRepository){
            _categorieRepository= categorieRepository;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categorieRepository.Categories.ToList());
        }

    }
}