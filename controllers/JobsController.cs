using JobRecruitment.Models;
using JobRecruitment.Services;
using JobRecruitment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobRecruitment.Controllers
{
    public class JobsController : Controller
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index(string query, string location, string type, int page = 1)
        {
            var filters = new Dictionary<string, List<string>>();
            
            if (!string.IsNullOrEmpty(type))
            {
                filters["type"] = new List<string> { type };
            }
            
            if (!string.IsNullOrEmpty(location))
            {
                filters["location"] = new List<string> { location };
            }

            var jobsResult = _jobService.SearchJobs(query, filters, page, 10);
            
            var viewModel = new JobsViewModel
            {
                Jobs = jobsResult.Jobs,
                Query = query,
                Location = location,
                JobType = type,
                CurrentPage = page,
                TotalPages = jobsResult.TotalPages
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var job = _jobService.GetJobById(id);
            
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        [HttpPost]
        public IActionResult Apply(int id)
        {
            // Check if user is authenticated
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", new { returnUrl = Url.Action("Details", "Jobs", new { id }) });
            }

            // Process job application
            // In a real application, you'd get the user ID from the claims and handle the application
            
            TempData["SuccessMessage"] = "Your application has been submitted successfully!";
            return RedirectToAction("Details", new { id });
        }
    }
}
