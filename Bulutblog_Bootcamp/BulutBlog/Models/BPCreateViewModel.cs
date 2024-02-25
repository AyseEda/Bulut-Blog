using System.ComponentModel.DataAnnotations;

namespace BulutBlog.Models
{

    public class BPCreateViewModel{

        [Required]
        [Display(Name = "Post Başlığı")]
        
        public string? Title {get; set;}

        [Required]
        [Display(Name = "Post Açıklama")]
        
        public string? Description {get; set;}

        [Required]
        [Display(Name = "Post İçeriği")]
        
        public string? Content {get; set;}

        [Required]
        [Display(Name = "Url Bilgisi")]
        
        public string? Url {get; set;}


    }
}