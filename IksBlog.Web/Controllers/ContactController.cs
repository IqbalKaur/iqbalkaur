using IksBlog.Data.Entities;
using IksBlog.Data.Repositories;
using IksBlog.Web.Models.ViewModels;
using IksBlog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace IksBlog.Web.Controllers;

public class ContactController : Controller
{
    private readonly IBlogRepository _blogRepository;
    private readonly IEmailSender _emailSender;

    public ContactController(IBlogRepository blogRepository, IEmailSender emailSender)
    {
        _blogRepository = blogRepository;
        _emailSender = emailSender;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(ContactViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        await _blogRepository.SaveContactMessageAsync(new ContactMessage
        {
            Name = model.Name,
            Email = model.Email,
            Phone = model.Phone,
            Message = model.Message
        });

        await _emailSender.SendAsync(
            $"Blog contact from {model.Name}",
            $"Name: {model.Name}\nEmail: {model.Email}\nPhone: {model.Phone}\n\n{model.Message}");

        ViewBag.Success = true;
        return View(new ContactViewModel());
    }
}
