using Microsoft.EntityFrameworkCore;

namespace Genevill.MVC.BugTracker.Data
{
    public class GenevillMVCBlogContext : DbContext
    {
        public GenevillMVCBlogContext(DbContextOptions<GenevillMVCBlogContext> options)
            : base(options)
        {
        }

        public DbSet<Genevill.MVC.BugTracker.Models.Blog> Blog { get; set; }
    }
}
