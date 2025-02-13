using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace XGame.Entity
{
    [Index ( nameof ( Title ), IsUnique = true )]
    public class CategoryEntity
    {
        [Key]
        public int ID { get; set; }

        [Required ( ErrorMessage = "Required" )]
        [MinLength ( 5, ErrorMessage = "min 5 character" )]
        public string? Title { get; set; }

        [Required ( ErrorMessage = "Required" )]
        [MinLength ( 5, ErrorMessage = "min 5 character" )]
        public string? TitleFarsi { get; set; }
        public string? Description { get; set; }

    }
}
