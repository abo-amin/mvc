using System;
using System.ComponentModel.DataAnnotations;

namespace JobRecruitment.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string? Title { get; set; }

        [Required]
        public string? Content { get; set; }

        [Required]
        public string? Excerpt { get; set; }

        public string? Image { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string? ReadTime { get; set; }

        public int Likes { get; set; }

        public int Comments { get; set; }

        // Navigation properties
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }

    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Avatar { get; set; }

        public string? Role { get; set; }

        // Navigation property
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
