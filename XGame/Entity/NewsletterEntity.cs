using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace XGame.Entity
{
    [Index ( nameof ( Email ), IsUnique = true )]
    public class NewsletterEntity
    {
        [Key]
        public int ID { get; set; }
        [Required ( ErrorMessage = "ادرس ایمیل را وارد کنید" )]
        [EmailAddress]
        public string? Email { get; set; }
        public DateTime RegisterAt { get; set; } = DateTime.UtcNow;
    }
}
