using JobRecruitment.Services;
using JobRecruitment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JobRecruitment.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IJobService _jobService;

        public CompaniesController(ICompanyService companyService, IJobService jobService)
        {
            _companyService = companyService;
            _jobService = jobService;
        }

        public IActionResult Index(string query, string industry, string location, int page = 1)
        {
            var filters = new Dictionary<string, List<string>>();
            
            if (!string.IsNullOrEmpty(industry))
            {
                filters["industry"] = new List<string> { industry };
            }
            
            if (!string.IsNullOrEmpty(location))
            {
                filters["location"] = new List<string> { location };
            }

            var companiesResult = _companyService.SearchCompanies(query, filters, page, 10);
            
            var viewModel = new CompaniesViewModel
            {
                Companies = companiesResult.Companies,
                Query = query,
                Industry = industry,
                Location = location,
                CurrentPage = page,
                TotalPages = companiesResult.TotalPages
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var company = _companyService.GetCompanyById(id);
            
            if (company == null)
            {
                return NotFound();
            }

            var companyJobs = _jobService.GetJobsByCompany(id);

            var viewModel = new CompanyDetailsViewModel
            {
                Company = company,
                Jobs = companyJobs
            };

            return View(viewModel);
        }
    }
}
