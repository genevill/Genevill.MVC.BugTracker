using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Genevill.MVC.BugTracker.Models
{
    public class BugReport
    {
        public int Id { get; set; }

#nullable enable
        public string? Summary { get; set; }
        
        public string? Assignee { get; set; }
        
        [Display(Name = "Affected User")]
        public string? AffectedUser { get; set; }

        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        public string? Status { get; set; }
        
        public string? Resolution { get; set; }
#nullable disable
        [DataType(DataType.Date)]
        public DateTime? Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Updated { get; set; }
    }
}