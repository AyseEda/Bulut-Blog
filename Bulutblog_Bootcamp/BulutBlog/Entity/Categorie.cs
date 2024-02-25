using System.ComponentModel.DataAnnotations;

namespace BulutBlog.Entity;

public class Categorie{
    [Key]
    public int CategoriId {get; set;}
    public string? Text {get; set;}
    public string? Url { get; set; }

    public List <BlogPost> BlogPosts {get; set;}= new List<BlogPost>();

}