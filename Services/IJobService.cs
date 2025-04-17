using JobRecruitment.Models;
using System.Collections.Generic;

namespace JobRecruitment.Services
{
    public interface IJobService
    {
        IEnumerable<Job> GetAllJobs();
        IEnumerable<Job> GetFeaturedJobs(int limit);
        Job GetJobById(int id);
        IEnumerable<Job> GetJobsByCompany(int companyId);
        (IEnumerable<Job> Jobs, int TotalPages) SearchJobs(string query, Dictionary<string, List<string>> filters, int page, int pageSize);
        int CreateJob(Job job);
        bool UpdateJob(Job job);
        bool DeleteJob(int id);
    }
}
