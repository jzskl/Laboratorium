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
        ViewBag.MaxPage = (count / pageSize) - (count % pageSize == 0 ? 1 : 0);
        
        return View(books);
    }

    public IActionResult Authors(int id, int page = 1, int pageSize = 20)
    {
        var book = _context.Books
            .Include(x => x.Authors)
            .ThenInclude(x => x.Books)
            .First(x => x.BookId == id);
        
        var authors = book.Authors
            .OrderBy(x => x.AuthorName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.BookTitle = book.Title;
        return View(authors);
    }
}