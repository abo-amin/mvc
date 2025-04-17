using JobRecruitment.Data;
using JobRecruitment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobRecruitment.Services
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Job> GetAllJobs()
        {
            return _context.Jobs
                .Include(j => j.CompanyObject)
                .ToList();
        }

        public IEnumerable<Job> GetFeaturedJobs(int limit)
        {
            return _context.Jobs
                .Include(j => j.CompanyObject)
                .OrderByDescending(j => j.Posted)
                .Take(limit)
                .ToList();
        }

        public Job GetJobById(int id)
        {
            return _context.Jobs
                .Include(j => j.CompanyObject)
                .FirstOrDefault(j => j.Id == id);
        }

        public IEnumerable<Job> GetJobsByCompany(int companyId)
        {
            return _context.Jobs
                .Where(j => j.CompanyId == companyId)
                .ToList();
        }

        public (IEnumerable<Job> Jobs, int TotalPages) SearchJobs(string query, Dictionary<string, List<string>> filters, int page, int pageSize)
        {
            var jobsQuery = _context.Jobs
                .Include(j => j.CompanyObject)
                .AsQueryable();

            // Apply search query
            if (!string.IsNullOrEmpty(query))
            {
                query = query.ToLower();
                jobsQuery = jobsQuery.Where(j => 
                    j.Title.ToLower().Contains(query) ||
                    j.Description.ToLower().Contains(query) ||
                    j.Company.ToLower().Contains(query) ||
                    j.Location.ToLower().Contains(query)
                );
            }

            // Apply filters
            if (filters != null)
            {
                if (filters.TryGetValue("type", out var jobTypes) && jobTypes.Any())
                {
                    jobsQuery = jobsQuery.Where(j => jobTypes.Contains(j.Type));
                }

                if (filters.TryGetValue("location", out var locations) && locations.Any())
                {
                    jobsQuery = jobsQuery.Where(j => locations.Any(l => j.Location.Contains(l)));
                }
            }

            // Get total count for pagination
            var totalItems = jobsQuery.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Apply pagination
            var jobs = jobsQuery
                .OrderByDescending(j => j.Posted)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (jobs, totalPages);
        }

        public int CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return job.Id;
        }

        public bool UpdateJob(Job job)
        {
            _context.Entry(job).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteJob(int id)
        {
            var job = _context.Jobs.Find(id);
            if (job == null)
            {
                return false;
            }

            _context.Jobs.Remove(job);
            _context.SaveChanges();
            return true;
        }
    }
}
