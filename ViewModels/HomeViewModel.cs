using JobRecruitment.Models;

namespace JobRecruitment.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Job>? FeaturedJobs { get; set; } = new List<Job>();
        public IEnumerable<Company>? FeaturedCompanies { get; set; } = new List<Company>();
    }
}
