using JobRecruitment.Data;
using JobRecruitment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobRecruitment.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts
                .Include(p => p.Author)
                .OrderByDescending(p => p.Date)
                .ToList();
        }

        public IEnumerable<Post> GetFeaturedPosts(int limit)
        {
            return _context.Posts
                .Include(p => p.Author)
                .OrderByDescending(p => p.Date)
                .Take(limit)
                .ToList();
        }

        public Post GetPostById(int id)
        {
            return _context.Posts
                .Include(p => p.Author)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetPostsByCategory(string category)
        {
            return _context.Posts
                .Include(p => p.Author)
                .Where(p => p.Category == category)
                .OrderByDescending(p => p.Date)
                .ToList();
        }

        public (IEnumerable<Post> Posts, int TotalPages) SearchPosts(string query, string category, int page, int pageSize)
        {
            var postsQuery = _context.Posts
                .Include(p => p.Author)
                .AsQueryable();

            // Apply search query
            if (!string.IsNullOrEmpty(query))
            {
                query = query.ToLower();
                postsQuery = postsQuery.Where(p => 
                    p.Title.ToLower().Contains(query) ||
                    p.Content.ToLower().Contains(query) ||
                    p.Excerpt.ToLower().Contains(query)
                );
            }

            // Apply category filter
            if (!string.IsNullOrEmpty(category))
            {
                postsQuery = postsQuery.Where(p => p.Category == category);
            }

            // Get total count for pagination
            var totalItems = postsQuery.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Apply pagination
            var posts = postsQuery
                .OrderByDescending(p => p.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (posts, totalPages);
        }

        public int CreatePost(string title, string content, string excerpt, string category, string image, int authorId)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                Excerpt = excerpt,
                Category = category,
                Image = image,
                AuthorId = authorId,
                Date = DateTime.Now,
                ReadTime = CalculateReadTime(content),
                Likes = 0,
                Comments = 0
            };

            _context.Posts.Add(post);
            _context.SaveChanges();
            return post.Id;
        }

        public bool LikePost(int id)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
            {
                return false;
            }

            post.Likes++;
            _context.SaveChanges();
            return true;
        }

        private string CalculateReadTime(string content)
        {
            // Calculate read time based on average reading speed of 200 words per minute
            var wordCount = content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            var minutes = Math.Max(1, (int)Math.Ceiling(wordCount / 200.0));
            return $"{minutes} min read";
        }
    }
}
