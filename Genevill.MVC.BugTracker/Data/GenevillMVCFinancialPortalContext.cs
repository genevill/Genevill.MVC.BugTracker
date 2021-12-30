using Microsoft.EntityFrameworkCore;

namespace Genevill.MVC.BugTracker.Data
{
    public class GenevillMVCFinancialPortalContext : DbContext
    {
        public GenevillMVCFinancialPortalContext(DbContextOptions<GenevillMVCFinancialPortalContext> options)
            : base(options)
        {
        }

        public DbSet<Genevill.MVC.BugTracker.Models.FinancialPortal> FinancialPortal { get; set; }
    }
}
