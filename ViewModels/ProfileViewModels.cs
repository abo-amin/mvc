using Microsoft.AspNetCore.Http;
using JobRecruitment.Models;
using System.Collections.Generic;

namespace JobRecruitment.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; } = default!;
        public IEnumerable<UserSkill> Skills { get; set; } = new List<UserSkill>();
        public IEnumerable<Experience> Experiences { get; set; } = new List<Experience>();
        public IEnumerable<Education> Education { get; set; } = new List<Education>();
        public int SavedJobsCount { get; set; }
        public int AppliedJobsCount { get; set; }
    }

    public class EditProfileViewModel
    {
        public string? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Location { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImage { get; set; }
        public IFormFile? ProfileImageFile { get; set; }
        
        public List<UserSkillViewModel> Skills { get; set; } = new List<UserSkillViewModel>();
        public List<ExperienceViewModel> Experiences { get; set; } = new List<ExperienceViewModel>();
        public List<EducationViewModel> Education { get; set; } = new List<EducationViewModel>();
    }

    public class UserSkillViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class ExperienceViewModel
    {
        public int Id { get; set; }
        public string? JobTitle { get; set; }
        public string? Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsCurrentlyWorking { get; set; }
        public string? Description { get; set; }
        
        // For form binding
        public string? StartDateStr { get; set; }
        public string? EndDateStr { get; set; }
    }

    public class EducationViewModel
    {
        public int Id { get; set; }
        public string? Degree { get; set; }
        public string? Institution { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public bool IsCurrentlyStudying { get; set; }
        public string? Description { get; set; }
    }
}
