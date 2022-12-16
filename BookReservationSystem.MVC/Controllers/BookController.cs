using BookReservationSystem.BL.Exceptions;
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
    public async Task<IActionResult> Index()
    {
        var books = await _bookService.FindAll();
        return View(books);
    }
    
    [HttpPost]
    public async Task<IActionResult> Index(BookFilterDto filter)
    {
        if (!ModelState.IsValid)
        {
            return View("Error");
        }
        
        var books = await _bookService.FilterBooks(filter);
        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid id)
    {
        var book = await _bookService.FindById(id);
        return book == null ? View("Error") : View("BookDetail", book);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Add()
    {
        return View("../Admin/AddBook");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(BookCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return View("../Admin/AddBook", createDto);
        }

        await _bookService.Insert(createDto);
        return RedirectToAction("Index", "Book");
    }

    

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.Delete(id);
        return RedirectToAction("Index", "Book");
    }
}