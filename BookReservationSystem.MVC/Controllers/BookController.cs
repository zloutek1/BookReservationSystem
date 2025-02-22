﻿using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookReservationSystem.MVC.Controllers;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IToastNotification _toastNotification;

    public BookController(IBookService bookService, IToastNotification toastNotification)
    {
        _bookService = bookService;
        _toastNotification = toastNotification;
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
        var books = await _bookService.FilterBooks(filter);
        return View(books);
    }

    [HttpGet]
    public async Task<IActionResult> Detail(Guid id)
    {
        var book = await _bookService.FindById(id);
        if (book == null)
        {
            _toastNotification.AddErrorToastMessage($"Book with id {id} not found");
            return RedirectToAction("Index", "Book");
        }
        return View("BookDetail", book);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(BookCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createDto);
        }

        try
        {
            await _bookService.Insert(createDto);
        }
        catch (ServiceException ex)
        {
            ModelState.AddModelError("message", "could not add: " + ex.Message);
            return View(createDto);
        }
        
        return RedirectToAction("Index", "Book");
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var foundBook = await _bookService.FindById(id);
        if (foundBook == null)
        {
            _toastNotification.AddErrorToastMessage($"Book with id {id} not found");
            return RedirectToAction("Detail", "Book", new { id });
        }

        var updateDto = new BookUpdateDto
        {
            Id = foundBook.Id,
            Name = foundBook.Name,
            Abstract = foundBook.Abstract,
            Isbn = foundBook.Isbn
        };
        return View(updateDto);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(BookUpdateDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateDto);
        }

        try
        {
            await _bookService.Update(updateDto);
        }
        catch (ServiceException ex)
        {
            ModelState.AddModelError("message", "could not update: " + ex.Message);
            return View(updateDto);
        }
        
        return RedirectToAction("Detail", "Book", new { id = updateDto.Id });
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _bookService.Delete(id);
        }
        catch (ServiceException ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);
        }

        return RedirectToAction("Index", "Book");
    }
}