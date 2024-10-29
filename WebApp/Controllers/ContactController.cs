using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1, new ContactModel()
        {
            Id = 1,
            FirstName = "Adam",
            LastName = "Abecki",
            Email = "adam@gmail.com",
            BirthDate = new DateOnly(2000, 10, 10),
            PhoneNumber = "+48 222 222 333"
        }},
        {2, new ContactModel()
        {
            Id = 2,
            FirstName = "Ewa",
            LastName = "Bebecka",
            Email = "ewq@gmail.com",
            BirthDate = new DateOnly(2001, 10, 10),
            PhoneNumber = "+48 222 222 333"
        }},
        {3, new ContactModel()
        {
            Id = 3,
            FirstName = "Karol",
            LastName = "Mały",
            Email = "karo@gmail.com",
            BirthDate = new DateOnly(1990, 10, 10),
            PhoneNumber = "+48 222 222 333"
        }},
    };

    private static int currentId = 3;
        
    // Lista kontaktów
    public IActionResult Index()
    {
        return View(_contacts.Values.ToList());
    }

    // Formularz dodania kontaktu
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    // Odebranie i zapisanie nowego kontaktu
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        model.Id = ++currentId; //_contacts.Keys.Max() + 1;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts.Values.ToList());
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts.Values.ToList());
    }
}