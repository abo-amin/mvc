using Microsoft.AspNetCore.Http;
using JobRecruitment.Models;
using System.Collections.Generic;

namespace JobRecruitment.ViewModels
{
    public class JobApplyViewModel
    {
        public int JobId { get; set; }
        public Job Job { get; set; } = new Job();
        public string? CoverLetter { get; set; }
        public IFormFile? ResumeFile { get; set; }
        public bool UseProfileResume { get; set; }
    }
    
    public class JobDetailsViewModel
    {
        public Job? Job { get; set; }
        public bool IsApplied { get; set; }
        public bool IsSaved { get; set; }
        public Company? Company { get; set; }
        public IEnumerable<Job> SimilarJobs { get; set; } = new List<Job>();
    }
}
