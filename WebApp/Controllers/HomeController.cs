using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator(Operator? op, double? a, double? b)
    {
        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator";
            return View("CustomError");
        }
        
        if (a is null || b is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze a lub b";
            return View("CustomError");
        }
        
        ViewBag.A = a;
        ViewBag.B = b;
        switch (op)
        {
            case Operator.Add:
                ViewBag.Operator = "+";
                ViewBag.Result = a + b;
                break;
            case Operator.Sub:
                ViewBag.Operator = "-";
                ViewBag.Result = a - b;
                break;
            case Operator.Mul:
                ViewBag.Operator = "*";
                ViewBag.Result = a * b;
                break;
            case Operator.Div:
                ViewBag.Operator = "/";
                ViewBag.Result = a / b;
                break;
        }
        return View();
    }

    public IActionResult Age(DateTime birth, DateTime future)
    {
        if (future < birth)
        {
            ViewBag.ErrorMessage = "Data urodzenia nie może być w przyszłości od daty future!";
            return View("CustomError");    
        }
        
        int years = future.Year - birth.Year;
        if (birth.Month == future.Month && future.Day < birth.Day || future.Month < birth.Month)
        {
            years--;
        }

        ViewBag.Age = years;
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Mul, Div
}