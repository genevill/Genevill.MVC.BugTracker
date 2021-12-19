using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Genevill.MVC.BugTracker.Models
{
    public class BugReport
    {
        public int Id { get; set; }

#nullable enable
        [StringLength(1000, MinimumLength = 3), Required]
        public string? Summary { get; set; }
        
        public string? Assignee { get; set; }
        
        [Display(Name = "Affected User")]
        public string? AffectedUser { get; set; }

        [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Please enter a contact number in the format 123-456-7890")]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        [RegularExpression(@"Pending|In\nProgress|Resolved|Closed", ErrorMessage = "Must be Pending, In Progress, Resolved, or Closed")]
        public string? Status { get; set; }
        
        public string? Resolution { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }
    }
}