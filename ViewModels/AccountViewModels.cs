using System.ComponentModel.DataAnnotations;
using JobRecruitment.Models;

namespace JobRecruitment.ViewModels
{
    public class LoginViewModel
    {
        [Required]
    //  
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "I agree to the terms and conditions")]
        public bool AgreeToTerms { get; set; }
    }

    public class DashboardViewModel
    {
        public ApplicationUser User { get; set; } = null!;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int AppliedJobs { get; set; }
        public int SavedJobs { get; set; }
        public IEnumerable<JobRecruitment.Models.Job> RecentApplications { get; set; } = new List<JobRecruitment.Models.Job>();
    }
}
