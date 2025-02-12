using System.ComponentModel.DataAnnotations;

namespace XGame.Models
{
    public class NewsletterDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
