using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
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

    [HttpPost]
    public IActionResult Result(CalculatorModel model)
    {
        if (!model.IsValid())
        {
            return View("CustomError");
        }
        return View(model);
    }
}

public enum Operators
{
    Add, Sub, Mul, Div
}