using System.ComponentModel.DataAnnotations;

namespace BulutBlog.Entity;

public class Comment{

    [Key]
    public int CommentId {get; set;}
    public string? Text {get; set;}
    public DateTime PublishedOn {get; set;}
    
    public int PostId {get; set;}
    public BlogPost Post { get; set; } = null!;

    public int UserId {get; set;}
    public User User {get; set;} = null!;

}