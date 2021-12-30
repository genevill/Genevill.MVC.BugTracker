using Microsoft.EntityFrameworkCore;

namespace Genevill.MVC.BugTracker.Data
{
    public class GenevillMVCBugTrackerContext : DbContext
    {
        public GenevillMVCBugTrackerContext(DbContextOptions<GenevillMVCBugTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Genevill.MVC.BugTracker.Models.BugReport> BugTracker { get; set; }
    }
}
