using JobRecruitment.Models;
namespace JobRecruitment.ViewModels
{
    public class CompaniesViewModel
    {
        public IEnumerable<Company> Companies { get; set; } = new List<Company>();
        public string? Query { get; set; }
        public string? Industry { get; set; }
        public string? Location { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
    }
    public class CompanyDetailsViewModel
    {
        public Company? Company { get; set; }
        public IEnumerable<Job>? Jobs { get; set; }
    }
}
