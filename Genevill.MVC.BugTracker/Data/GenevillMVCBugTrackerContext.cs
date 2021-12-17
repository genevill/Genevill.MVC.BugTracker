using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Genevill.MVC.BugTracker.Models;

namespace Genevill.MVC.BugTracker.Data
{
    public class GenevillMVCBugTrackerContext : DbContext
    {
        public GenevillMVCBugTrackerContext (DbContextOptions<GenevillMVCBugTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Genevill.MVC.BugTracker.Models.BugReport> BugTracker { get; set; }
    }
}
