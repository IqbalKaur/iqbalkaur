using System.Security.Claims;
using IksBlog.Data.Entities;
using IksBlog.Data.Repositories;
using IksBlog.Web.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IksBlog.Web.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly IBlogRepository _blogRepository;

    public AdminController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        ViewBag.HeroImage = "admin-bg.jpg";
        ViewBag.PageTitle = "Manage Blog Posts";

        var total = await _blogRepository.GetTotalPostCountAsync();
        var posts = total == 0
            ? new List<BlogPost>()
            : await _blogRepository.GetPagedPostsAsync(1, total);

        return View(posts);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _blogRepository.DeletePostAsync(id);
        TempData["Success"] = "Post deleted";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.HeroImage = "admin-bg.jpg";
        ViewBag.PageTitle = "New Post";
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreatePostViewModel model)
    {
        ViewBag.HeroImage = "admin-bg.jpg";
        ViewBag.PageTitle = "New Post";

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdClaim))
        {
            return Unauthorized();
        }

        var post = new BlogPost
        {
            PostTitle = model.PostTitle,
            PostSubTitle = model.PostSubTitle,
            Content = model.Content,
            UserId = int.Parse(userIdClaim),
            CreatedAt = DateTime.UtcNow.ToString("o")
        };

        await _blogRepository.CreatePostAsync(post);
        TempData["Success"] = "Post created";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _blogRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        ViewBag.HeroImage = "admin-bg.jpg";
        ViewBag.PageTitle = "Edit Post";

        var model = new EditPostViewModel
        {
            PostTitle = post.PostTitle,
            PostSubTitle = post.PostSubTitle,
            Content = post.Content
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, EditPostViewModel model)
    {
        ViewBag.HeroImage = "admin-bg.jpg";
        ViewBag.PageTitle = "Edit Post";

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var post = await _blogRepository.GetPostByIdAsync(id);
        if (post == null)
        {
            return NotFound();
        }

        post.PostTitle = model.PostTitle;
        post.PostSubTitle = model.PostSubTitle;
        post.Content = model.Content;

        await _blogRepository.UpdatePostAsync(post);
        TempData["Success"] = "Post updated";
        return RedirectToAction(nameof(Index));
    }
}
