using IksBlog.Data.Entities;
using IksBlog.Data.Repositories;
using IksBlog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IksBlog.Web.Controllers;

public class BlogController : Controller
{
    private const int PageSize = 5;
    private readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        var posts = await _blogRepository.GetPagedPostsAsync(page, PageSize);
        var total = await _blogRepository.GetTotalPostCountAsync();
        var totalPages = (int)Math.Ceiling(total / (double)PageSize);

        var viewModel = new BlogIndexViewModel
        {
            Posts = posts,
            CurrentPage = page,
            TotalPages = totalPages
        };

        return View(viewModel);
    }

    public async Task<IActionResult> Post(int id)
    {
        var post = await _blogRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> AddComment(int postId, string name, string email, string comment)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(comment))
        {
            return BadRequest();
        }

        await _blogRepository.AddCommentAsync(new Comment
        {
            PostId = postId,
            Name = name,
            Email = email,
            CommentText = comment
        });

        return Redirect($"/Blog/Post?id={postId}#comments");
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Portfolio()
    {
        return View();
    }
}
