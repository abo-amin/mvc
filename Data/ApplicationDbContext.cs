using JobRecruitment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobRecruitment.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; } = default!;
        public DbSet<Company> Companies { get; set; } = default!;
        public DbSet<Post> Posts { get; set; } = default!;
        public DbSet<Author> Authors { get; set; } = default!;
        public DbSet<Experience> Experiences { get; set; } = default!;
        public DbSet<Education> Educations { get; set; } = default!;
        public DbSet<UserSkill> UserSkills { get; set; } = default!;
        public DbSet<SavedJob> SavedJobs { get; set; } = default!;
        public DbSet<JobApplication> JobApplications { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships
            modelBuilder.Entity<Job>()
                .HasOne(j => j.CompanyObject)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CompanyId);

            modelBuilder.Entity<Post>()
                .HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId);

            modelBuilder.Entity<UserSkill>()
                .HasOne(us => us.User)
                .WithMany(u => u.Skills)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<Experience>()
                .HasOne(e => e.User)
                .WithMany(u => u.Experiences)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Education>()
                .HasOne(e => e.User)
                .WithMany(u => u.Educations)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.User)
                .WithMany(u => u.SavedJobs)
                .HasForeignKey(sj => sj.UserId);

            modelBuilder.Entity<SavedJob>()
                .HasOne(sj => sj.Job)
                .WithMany()
                .HasForeignKey(sj => sj.JobId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany(u => u.AppliedJobs)
                .HasForeignKey(ja => ja.UserId);

            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.Job)
                .WithMany(j => j.Applications)
                .HasForeignKey(ja => ja.JobId);
        }
    }
}
