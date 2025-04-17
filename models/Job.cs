using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobRecruitment.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Title { get; set; }

        [Required]
        public string? Company { get; set; }

        public string? Logo { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public string? Type { get; set; }

        public string? Salary { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Posted { get; set; }

        [Required]
        public string? Description { get; set; }

        public List<string> Requirements { get; set; } = new List<string>();

        public List<string> Benefits { get; set; } = new List<string>();

        // Navigation properties
        public int CompanyId { get; set; }
        public Company? CompanyObject { get; set; }
        
        public ICollection<JobApplication> Applications { get; set; } = new List<JobApplication>();
    }
}
