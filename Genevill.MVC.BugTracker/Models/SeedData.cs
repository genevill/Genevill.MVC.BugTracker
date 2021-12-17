using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Genevill.MVC.BugTracker.Data;
using System;
using System.Linq;

namespace Genevill.MVC.BugTracker.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new GenevillMVCBugTrackerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GenevillMVCBugTrackerContext>>());
            // Look for any bugs.
            if (context.BugTracker.Any())
            {
                return;   // DB has been seeded
            }

            context.BugTracker.AddRange(
                new BugReport
                {
                    Summary = "Bug 1",
                    Assignee = "Me",
                    AffectedUser = "You",
                    PhoneNumber = "1234567890",
                    Status = "In Progress",
                    Resolution = "Pending",
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                },
                new BugReport
                {
                    Summary = "Bug 2",
                    Assignee = "Me",
                    AffectedUser = "You",
                    PhoneNumber = "1234567890",
                    Status = "In Progress",
                    Resolution = "Pending",
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                }
            );
            context.SaveChanges();
        }
    }
}