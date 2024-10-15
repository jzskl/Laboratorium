using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Result(Operators? op, double? a, double? b)
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
            case Operators.Add:
                ViewBag.Operator = "+";
                ViewBag.Result = a + b;
                break;
            case Operators.Sub:
                ViewBag.Operator = "-";
                ViewBag.Result = a - b;
                break;
            case Operators.Mul:
                ViewBag.Operator = "*";
                ViewBag.Result = a * b;
                break;
            case Operators.Div:
                ViewBag.Operator = "/";
                ViewBag.Result = a / b;
                break;
        }
        return View();
    }
}

public enum Operators
{
    Add, Sub, Mul, Div
}