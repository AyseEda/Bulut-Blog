using BulutBlog.Data.Abstract;
using BulutBlog.Data.Concrete;
using BulutBlog.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options=>{
    var config= builder.Configuration;
    var connectionString= config.GetConnectionString("sql_connection");
    options.UseSqlite(connectionString);
    
});

builder.Services.AddScoped<IBlogPostRepository, EfBlogPostRepository>();
builder.Services.AddScoped<ICategorieRepository, EfCategorieRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentsRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

/*void AddScoped<T1, T2>()
{
    throw new NotImplementedException();
}*/

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();


var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


SeedData.TestVerileri(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "blogposts-details",
    pattern: "blogposts/details/{url}",
    defaults: new{controller= "BlogPosts", action="Details"}
    );

   /* app.MapControllerRoute(
    name: "user_profile",
    pattern: "profile/{username}",
    defaults: new {controller = "Users", action = "Profile" }
);*/


    /*app.MapControllerRoute(
    name: "blogpost_by_categorie",
    pattern: "blogposts/categories/{categorie}",
    defaults: new{controller= "BlogPosts", action="Details"}
    );*/

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BlogPosts}/{action=Index}/{id?}");

app.Run();
