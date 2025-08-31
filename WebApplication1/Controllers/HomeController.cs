using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly SpamService spamService;

    public HomeController()
    {
        spamService = new SpamService();
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string message)
    {
        bool isSpam = spamService.Predict(message);
        ViewBag.Message = message;
        ViewBag.Prediction = isSpam ? "SPAM" : "HAM";
        return View();
    }
}