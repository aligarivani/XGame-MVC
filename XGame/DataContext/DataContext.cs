using Microsoft.EntityFrameworkCore;
using XGame.Entity;
using XGame.Models;

namespace XGame.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> dbContext) : base ( dbContext )
        {

        }

        public DbSet<UserEntity> Users { get; set; }

    }
}
