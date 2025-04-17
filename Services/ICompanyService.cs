using JobRecruitment.Models;
using System.Collections.Generic;

namespace JobRecruitment.Services
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        IEnumerable<Company> GetFeaturedCompanies(int limit);
        Company GetCompanyById(int id);
        (IEnumerable<Company> Companies, int TotalPages) SearchCompanies(string query, Dictionary<string, List<string>> filters, int page, int pageSize);
        int CreateCompany(Company company);
        bool UpdateCompany(Company company);
        bool DeleteCompany(int id);
    }
}
