using JobRecruitment.Data;
using JobRecruitment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobRecruitment.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Job> GetSavedJobs(string userId)
        {
            return _context.SavedJobs
                .Where(sj => sj.UserId == userId)
                .Include(sj => sj.Job)
                .ThenInclude(j => j.CompanyObject)
                .Select(sj => sj.Job)
                .ToList();
        }

        public IEnumerable<JobApplication> GetAppliedJobs(string userId)
        {
            return _context.JobApplications
                .Where(ja => ja.UserId == userId)
                .Include(ja => ja.Job)
                .ThenInclude(j => j.CompanyObject)
                .ToList();
        }

        public bool SaveJob(string userId, int jobId)
        {
            // Check if already saved
            var existingSave = _context.SavedJobs
                .FirstOrDefault(sj => sj.UserId == userId && sj.JobId == jobId);

            if (existingSave != null)
            {
                return true; // Already saved
            }

            var savedJob = new SavedJob
            {
                UserId = userId,
                JobId = jobId,
                SavedDate = DateTime.Now
            };

            _context.SavedJobs.Add(savedJob);
            _context.SaveChanges();
            return true;
        }

        public bool ApplyForJob(string userId, int jobId, string coverLetter)
        {
            // Check if already applied
            var existingApplication = _context.JobApplications
                .FirstOrDefault(ja => ja.UserId == userId && ja.JobId == jobId);

            if (existingApplication != null)
            {
                return false; // Already applied
            }

            var application = new JobApplication
            {
                UserId = userId,
                JobId = jobId,
                CoverLetter = coverLetter,
                ApplicationDate = DateTime.Now,
                Status = "pending"
            };

            _context.JobApplications.Add(application);
            _context.SaveChanges();
            return true;
        }

        public bool AddExperience(string userId, Experience experience)
        {
            experience.UserId = userId;
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return true;
        }

        public bool AddEducation(string userId, Education education)
        {
            education.UserId = userId;
            _context.Educations.Add(education);
            _context.SaveChanges();
            return true;
        }

        public bool AddSkill(string userId, string skillName)
        {
            // Check if skill already exists
            var existingSkill = _context.UserSkills
                .FirstOrDefault(us => us.UserId == userId && us.SkillName == skillName);

            if (existingSkill != null)
            {
                return true; // Skill already exists
            }

            var skill = new UserSkill
            {
                UserId = userId,
                SkillName = skillName
            };

            _context.UserSkills.Add(skill);
            _context.SaveChanges();
            return true;
        }
    }
}
