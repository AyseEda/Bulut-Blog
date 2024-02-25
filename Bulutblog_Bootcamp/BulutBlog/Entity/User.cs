using System.ComponentModel.DataAnnotations;

namespace BulutBlog.Entity;

public class User{
    [Key]
    public int UserId {get; set;}
    public string? UserName {get; set;}
    public string? Name {get; set;}
    public string? Email {get; set;}
    public string? Password {get; set;}
    public string? Image {get; set;}

    public List <BlogPost> BlogPosts {get; set;}= new List<BlogPost>();
    public List <Comment> Comments {get; set;}= new List <Comment> ();

}