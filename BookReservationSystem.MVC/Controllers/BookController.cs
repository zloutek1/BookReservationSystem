using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IActionResult Index(Guid? bookId)
    {
        if (!bookId.HasValue)
        {
            var books = _bookService.FindAll();
            return View(books);
        }
        else
        {
            return BookDetail(bookId.Value);
        }
    }

    private IActionResult BookDetail(Guid bookId)
    {
        var book = _bookService.FindById(bookId);
        return book == null ? View("Error") : View(nameof(BookDetail), book);
    }
        
    [HttpPost]
    public IActionResult Search(BookFilterDto filter)
    {
        /*
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        */
        
        var books = _bookService.FilterBooks(filter);
        return View("Index", books);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Add()
    {
        return View("../Admin/AddBook");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Add(BookDto createDto)
    {
        /*
        if (!ModelState.IsValid)
        {
            return View("../Admin/AddBook", createDto);
        }
        */
        _bookService.Insert(createDto);
        return RedirectToAction("Index", "Book");
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(Guid id)
    {
        _bookService.Delete(id);
        return RedirectToAction("Index", "Book");
    }
}