using JobRecruitment.Services;
using JobRecruitment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobRecruitment.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index(string query, string category, int page = 1)
        {
            var postsResult = _postService.SearchPosts(query, category, page, 10);
            
            var viewModel = new PostsViewModel
            {
                Posts = postsResult.Posts,
                Query = query,
                Category = category,
                CurrentPage = page,
                TotalPages = postsResult.TotalPages
            };

            return View(viewModel);
        }

        public IActionResult Details(int id)
        {
            var post = _postService.GetPostById(id);
            
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // In a real app, you'd get the author ID from the user claims
            var authorId = 1; // Mock author ID

            var postId = _postService.CreatePost(
                model.Title,
                model.Content,
                model.Excerpt,
                model.Category,
                model.Image,
                authorId
            );

            return RedirectToAction(nameof(Details), new { id = postId });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Like(int id)
        {
            var success = _postService.LikePost(id);
            
            if (!success)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
