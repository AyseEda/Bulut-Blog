using BulutBlog.Entity;
using Microsoft.EntityFrameworkCore;

namespace BulutBlog.Data.Concrete.EfCore
{

    public static class SeedData{

        public static void TestVerileri(IApplicationBuilder app){

            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Categories.Any()){
                    context.Categories.AddRange(
                        new Categorie {Text= "Bilim ve Teknoloji",Url="bilimteknoloji"},
                        new Categorie {Text= "Yazılım",Url="yazılım"},
                        new Categorie {Text= "Network",Url="network"},
                        new Categorie {Text= "Yapay Zeka",Url="yapayzeka"},
                        new Categorie {Text= "Teknoloji her yerde",Url="teknolojiheryerde"}
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any()){
                    context.Users.AddRange(
                        new User{UserName="emelgul", Name = "Emel Gul", Email = "info@emelgul.com", Password="123456", Image="user2.jpg"},
                        new User{UserName="feyzanur", Name = "Feyza Nur", Email = "info@feyzanur.com", Password="123456", Image="user2.jpg"},
                        new User{UserName="edagul", Name = "Eda Gul", Email = "info@eda.com", Password="123456", Image="user2.jpg"},
                        new User{UserName="akifaltın", Name = "Akif Altın", Email = "info@akif.com", Password="123456", Image="user2.jpg"}
                    );
                    context.SaveChanges();

                }

                if(!context.BlogPosts.Any()){
                    context.BlogPosts.AddRange(
                        new BlogPost{
                            Title="Bulut suya aç!",
                            Description="Bulut sistemlerin bilinmeyen yönü",
                            Url="bilimteknoloji",
                            Content="Bulut sistemler çok fazla su tüketiyor.",
                            Image="1.jpg",
                            IsActive= true,
                            PublishedOn= DateTime.Now.AddDays(-14),
                            Cotegories= context.Categories.Take(1).ToList(),
                            UserId=1,
                            Comments= new List<Comment>{
                                new Comment {Text="Çok önemli bir konu", PublishedOn=new DateTime(),UserId=1},
                                new Comment {Text="Bu bilgilendirme için çok teşekkürler", PublishedOn=new DateTime(),UserId=2}
                            }
                        },
                        new BlogPost{
                            Title="Yapay Zeka Sağlıkta",
                            Description="yapay zeka ve sağlığın muhteşem birleşimi",
                            Url="teknolojiheryerde",
                            Content="teknoloji ve sağlık",
                            Image="yapayzeka.jpg",
                            IsActive= true,
                            PublishedOn= DateTime.Now.AddDays(-4),
                            Cotegories= context.Categories.Take(4).ToList(),
                            UserId=2
                        },
                         new BlogPost{
                            Title="Gpt Sağlık Alanına etkisi",
                            Description="Gpt sağlık alanında kullanmak mümkün mü?",
                            Url="teknolojisaglık",
                            Content="teknoloji ve sağlıkta son gelişmeler",
                            Image="ai1.jpg",
                            IsActive= true,
                            PublishedOn= DateTime.Now.AddDays(-5),
                            Cotegories= context.Categories.Take(4).ToList(),
                            UserId=2
                        },
                         new BlogPost{
                            Title="Tıp Alanındaki Teknolojik Gelişmeler",
                            Description="Hasta takip uygulamalarının son durumu",
                            Url="teknolojigelisiyor",
                            Content="teknoloji ve sağlık",
                            Image="tip.jpg",
                            IsActive= true,
                            PublishedOn= DateTime.Now.AddDays(-2),
                            Cotegories= context.Categories.Take(4).ToList(),
                            UserId=2
                        },
                        new BlogPost{
                            Title="Network alanındaki son çalışmalar",
                            Description="Sistem odalarında bulunan cihazlar",
                            Url="network",
                            Content="Network cihazları",
                            Image="bulut.jpg",
                            IsActive= true,
                            PublishedOn= DateTime.Now.AddDays(-3),
                            Cotegories= context.Categories.Take(3).ToList(),
                            UserId=1
                        }
                    );
                    context.SaveChanges();
                }

             }

        }

    }

}