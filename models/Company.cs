using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JobRecruitment.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        public string? Logo { get; set; }

        public string? Industry { get; set; }

        public string? Location { get; set; }

        public string? Description { get; set; }

        public string? Website { get; set; }

        [Required]
        public int Founded { get; set; }

        [Required]
        public string? Size { get; set; }

        public int OpenPositions { get; set; }

        // Navigation property
        public ICollection<Job> Jobs { get; set; } = new List<Job>();
    }
}
