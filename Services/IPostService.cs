using JobRecruitment.Models;
using System.Collections.Generic;

namespace JobRecruitment.Services
{
    public interface IPostService
    {
        IEnumerable<Post> GetAllPosts();
        IEnumerable<Post> GetFeaturedPosts(int limit);
        Post GetPostById(int id);
        IEnumerable<Post> GetPostsByCategory(string category);
        (IEnumerable<Post> Posts, int TotalPages) SearchPosts(string query, string category, int page, int pageSize);
        int CreatePost(string title, string content, string excerpt, string category, string image, int authorId);
        bool LikePost(int id);
    }
}
