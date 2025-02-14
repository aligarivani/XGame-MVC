using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace XGame.Models
{
    [Index ( nameof ( Title ), IsUnique = true )]
    public class CategoryDTO
    {
        [Required ( ErrorMessage = "Required" )]
        [MinLength ( 5, ErrorMessage = "min 5 character" )]
        public string? Title { get; set; }

        [Required ( ErrorMessage = "Required" )]
        [MinLength ( 5, ErrorMessage = "min 5 character" )]
        public string? TitleFarsi { get; set; }
        public string? Description { get; set; }
    }
}
