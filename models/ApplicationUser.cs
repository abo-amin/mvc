using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace JobRecruitment.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ProfileImage { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Bio { get; set; }
        public string? UserRole { get; set; } // "jobseeker", "employer", "admin"

        // Navigation properties
        public ICollection<UserSkill> Skills { get; set; } = new List<UserSkill>();
        public ICollection<Experience> Experiences { get; set; } = new List<Experience>();
        public ICollection<Education> Educations { get; set; } = new List<Education>();
        public ICollection<SavedJob> SavedJobs { get; set; } = new List<SavedJob>();
        public ICollection<JobApplication> AppliedJobs { get; set; } = new List<JobApplication>();
    }

    public class UserSkill
    {
        public int Id { get; set; }
        public string? SkillName { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }

    public class Experience
    {
        public int Id { get; set; }
        public string? Company { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool Current { get; set; }
        public string? Description { get; set; }
        
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }

    public class Education
    {
        public int Id { get; set; }
        public string? School { get; set; }
        public string? Degree { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }

    public class SavedJob
    {
        public int Id { get; set; }
        public DateTime SavedDate { get; set; }
        
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        
        public int JobId { get; set; }
        public Job? Job { get; set; }
    }

    public class JobApplication
    {
        public int Id { get; set; }
        public DateTime ApplicationDate { get; set; }
        public string? Status { get; set; } // "pending", "reviewed", "interviewed", "rejected", "accepted"
        public string? CoverLetter { get; set; }
        
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        
        public int JobId { get; set; }
        public Job? Job { get; set; }
    }
}
