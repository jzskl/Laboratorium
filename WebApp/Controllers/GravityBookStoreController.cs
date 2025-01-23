using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.GravityBookStore;

namespace WebApp.Controllers;

public class GravityBookStoreController : Controller
{
    private readonly GravityBookStoreDbContext _context;

    public GravityBookStoreController(GravityBookStoreDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index(int page = 1, int pageSize = 20)
    {
        var books = _context.Books
            .Include(x => x.Authors)
            .Select(x => new BookModel
            {
                BookId = x.BookId,
                Title = x.Title,
                ISBN13 = x.ISBN13,
                NumPages = x.NumPages ?? 0,
                PublicationDate = x.PublicationDate,
                AuthorsCount = x.Authors.Count,
                SoldCount = 0
            })
            .OrderBy(x => x.Title)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        foreach (var book in books)
        {
            // TODO: SoldCount
        }
        
        var count = _context.Books.Count();
        ViewBag.Page = page;
        ViewBag.PageSize = pageSize;
        ViewBag.MaxPage = (count / pageSize) - (count % pageSize == 0 ? 1 : 0) + 1;
        
        return View(books);
    }

    [Authorize(Roles = "user, admin")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "user, admin")]
    public IActionResult Add(BookModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var book = new BookEntity
        {
            Title = model.Title,
            ISBN13 = model.ISBN13,
            NumPages = model.NumPages,
            PublicationDate = model.PublicationDate,
        };
        _context.Books.Add(book);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [Authorize(Roles = "user, admin")]
    public IActionResult Edit(int id)
    {
        var book = _context.Books.Find(id);
        return View(new BookModel
        {
            BookId = book.BookId,
            Title = book.Title,
            ISBN13 = book.ISBN13,
            NumPages = book.NumPages ?? 0,
            PublicationDate = book.PublicationDate,
        });
    }

    [HttpPost]
    [Authorize(Roles = "user, admin")]
    public IActionResult Edit(BookModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var book = _context.Books.Find(model.BookId);
        book.Title = model.Title;
        book.ISBN13 = model.ISBN13;
        book.NumPages = model.NumPages;
        book.PublicationDate = model.PublicationDate;
        _context.SaveChanges();
        
        return RedirectToAction("Index");
    }

    public IActionResult Authors(int id, int page = 1, int pageSize = 20)
    {
        var book = _context.Books
            .Include(x => x.Authors)
            .ThenInclude(x => x.Books)
            .First(x => x.BookId == id);

        var query = book.Authors
            .OrderBy(x => x.AuthorName);
        
        var count = query.Count();
        var authors = book.Authors
            .OrderBy(x => x.AuthorName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        ViewBag.Page = page;
        ViewBag.PageSize = pageSize;
        ViewBag.MaxPage = (count / pageSize) - (count % pageSize == 0 ? 1 : 0) + 1;
        
        ViewBag.BookTitle = book.Title;
        ViewBag.Id = id;
        return View(authors);
    }
}