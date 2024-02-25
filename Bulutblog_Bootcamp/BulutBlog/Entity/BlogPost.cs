using System.ComponentModel.DataAnnotations;

namespace BulutBlog.Entity;

    public class BlogPost{
    
        [Key]
        public int PostId {get; set;}
        public string? Title {get; set;}
        public string? Description { get; set; }
        public string? Content {get; set;}
         public string? Url { get; set; }
        public string? Image {get; set;}
        public DateTime PublishedOn {get; set;}
        public bool IsActive {get; set;}

        public int UserId {get; set;}
        public User User {get; set;}= null!;

        public List <Categorie> Cotegories {get; set;}= new List <Categorie> ();
        public List <Comment> Comments {get; set;}= new List <Comment> ();
    
}
