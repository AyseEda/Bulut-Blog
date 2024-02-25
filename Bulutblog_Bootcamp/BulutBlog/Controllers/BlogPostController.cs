using System.Security.Claims;
using BulutBlog.Data.Abstract;
using BulutBlog.Data.Concrete.EfCore;
using BulutBlog.Entity;
using BulutBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulutBlog.Controllers
{
    public class BlogPostsController : Controller{

        private IBlogPostRepository _blogpostRepository;

        private ICommentRepository _commentRepository;

        //private readonly ICategorieRepository _categorieRepository;

        public BlogPostsController(IBlogPostRepository blogpostRepository, ICommentRepository commentRepository){
            _blogpostRepository = blogpostRepository;
            _commentRepository= commentRepository;
            
        }

        public IActionResult Index()
        {

            var claims = User.Claims;

            
            return View(
                new BlogPostViewModel{
                    BlogPosts= _blogpostRepository.BlogPosts.ToList()
                    //Categories= _categorieRepository.Categories.ToList()
                }
            );
        }

        public async Task<IActionResult> Details(string url){
            return View(await _blogpostRepository
            .BlogPosts
            .Include(x=>x.Comments)
            .ThenInclude(x=> x.User)
            .FirstOrDefaultAsync(p=>p.Url== url));
        }

        [HttpPost]
        public JsonResult AddComment(int PostId, string Text){

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username = User.FindFirstValue(ClaimTypes.Name);
             var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity= new Comment{
                PostId = PostId,
                Text = Text,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComments(entity);

            return Json(new{
                username,
                Text,
                entity.PublishedOn,
                avatar

            });

            //return View();
        }

        public IActionResult Create(BPCreateViewModel model){

            if(ModelState.IsValid){

                var userId= User.FindFirstValue(ClaimTypes.NameIdentifier);

                _blogpostRepository.CreateBlogPost(

                    new BlogPost{

                        Title = model.Title,
                        Content = model.Content,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        Image = "cat1.jpg",
                        PublishedOn = DateTime.Now,
                        IsActive = false

                    }
                );
                return RedirectToAction("Index");
            }

            return View(model);
        }
    }
}