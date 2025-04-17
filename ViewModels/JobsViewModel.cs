using JobRecruitment.Models;

namespace JobRecruitment.ViewModels
{
    public class JobsViewModel
    {
        public IEnumerable<Job> Jobs { get; set; } = new List<Job>();
        public string? SearchTerm { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string? Query { get; set; }
        public string? JobType { get; set; }
    }
}
