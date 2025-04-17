using JobRecruitment.Data;
using JobRecruitment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobRecruitment.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _context;

        public CompanyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Company> GetAllCompanies()
        {
            return _context.Companies
                .Include(c => c.Jobs)
                .ToList();
        }

        public IEnumerable<Company> GetFeaturedCompanies(int limit)
        {
            return _context.Companies
                .OrderByDescending(c => c.OpenPositions)
                .Take(limit)
                .ToList();
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies
                .Include(c => c.Jobs)
                .FirstOrDefault(c => c.Id == id);
        }

        public (IEnumerable<Company> Companies, int TotalPages) SearchCompanies(string query, Dictionary<string, List<string>> filters, int page, int pageSize)
        {
            var companiesQuery = _context.Companies.AsQueryable();

            // Apply search query
            if (!string.IsNullOrEmpty(query))
            {
                query = query.ToLower();
                companiesQuery = companiesQuery.Where(c => 
                    c.Name.ToLower().Contains(query) ||
                    c.Description.ToLower().Contains(query) ||
                    c.Industry.ToLower().Contains(query)
                );
            }

            // Apply filters
            if (filters != null)
            {
                if (filters.TryGetValue("industry", out var industries) && industries.Any())
                {
                    companiesQuery = companiesQuery.Where(c => industries.Contains(c.Industry));
                }

                if (filters.TryGetValue("location", out var locations) && locations.Any())
                {
                    companiesQuery = companiesQuery.Where(c => locations.Any(l => c.Location.Contains(l)));
                }
            }

            // Get total count for pagination
            var totalItems = companiesQuery.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Apply pagination
            var companies = companiesQuery
                .OrderByDescending(c => c.OpenPositions)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (companies, totalPages);
        }

        public int CreateCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return company.Id;
        }

        public bool UpdateCompany(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
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

        public bool DeleteCompany(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null)
            {
                return false;
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();
            return true;
        }
    }
}
