using JobRecruitment.Models;

namespace JobRecruitment.ViewModels
{
    public class PostsViewModel
    {
        public IEnumerable<Post> Posts { get; set; } = new List<Post>();
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public string? Query { get; set; }
        public string? Category { get; set; }
    }

    public class CreatePostViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string? Excerpt { get; set; }
        public string? Image { get; set; }
    }
}
