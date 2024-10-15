using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Form()
    {
        return View();
    }

    public IActionResult Result(BirthModel model)
    {
        if (!model.IsValid())
        {
            return View("CustomError");
        }
        return View(model);
    }
}