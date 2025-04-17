using JobRecruitment.Models;
using JobRecruitment.Services;
using JobRecruitment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobRecruitment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService _jobService;
        private readonly ICompanyService _companyService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IJobService jobService,
            ICompanyService companyService,
            ILogger<HomeController> logger)
        {
            _jobService = jobService;
            _companyService = companyService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var viewModel = new HomeViewModel
            {
                FeaturedJobs = _jobService.GetFeaturedJobs(4),
                FeaturedCompanies = _companyService.GetFeaturedCompanies(6)
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
