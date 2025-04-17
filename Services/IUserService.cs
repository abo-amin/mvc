using JobRecruitment.Models;
using System.Collections.Generic;

namespace JobRecruitment.Services
{
    public interface IUserService
    {
        IEnumerable<Job> GetSavedJobs(string userId);
        IEnumerable<JobApplication> GetAppliedJobs(string userId);
        bool SaveJob(string userId, int jobId);
        bool ApplyForJob(string userId, int jobId, string coverLetter);
        bool AddExperience(string userId, Experience experience);
        bool AddEducation(string userId, Education education);
        bool AddSkill(string userId, string skillName);
    }
}
