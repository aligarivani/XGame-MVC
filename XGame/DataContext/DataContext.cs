using Microsoft.EntityFrameworkCore;
using XGame.Entity;

namespace XGame.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> dbContext) : base ( dbContext )
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<NewsletterEntity> Newsletter { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
    }
}
