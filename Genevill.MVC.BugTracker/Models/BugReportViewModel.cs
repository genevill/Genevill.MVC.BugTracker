using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Genevill.MVC.BugTracker.Models
{
    public class BugReportViewModel
    {
#nullable enable
        public List<BugReport>? BugReports { get; set; }
        public SelectList? Assignees { get; set; }
        public string? AssigneeSearch { get; set; }
        public string? SearchString { get; set; }
#nullable disable
    }
}
