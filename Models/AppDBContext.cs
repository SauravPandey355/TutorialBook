namespace TutorialBook.Models
{
    using Microsoft.EntityFrameworkCore;
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<TutorialBookData> TutorialBooks { get; set; }
    }
}
