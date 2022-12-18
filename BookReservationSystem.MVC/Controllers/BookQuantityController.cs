﻿using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookReservationSystem.MVC.Controllers;

public class BookQuantityController: Controller
{
    private readonly IBookQuantityService _bookQuantityService;
    private readonly IToastNotification _toastNotification;

    public BookQuantityController(IBookQuantityService bookQuantityService, IToastNotification toastNotification)
    {
        _bookQuantityService = bookQuantityService;
        _toastNotification = toastNotification;
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult AddBook(Guid id)
    {
        var createDto = new BookQuantityCreateDto
        {
            LibraryId = id
        };
        return View(createDto);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> AddBook(BookQuantityCreateDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createDto);
        }

        await _bookQuantityService.Insert(createDto);
        return RedirectToAction("Detail", "Library", new { id = createDto.LibraryId });
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditCount(Guid libraryId, Guid bookId)
    {
        var record = await _bookQuantityService.FindById(libraryId, bookId);
        if (record == null)
        {
            _toastNotification.AddErrorToastMessage($"Record for book with id: {bookId} in library with id: {libraryId} not found");
            return RedirectToAction("Detail", "Library", new { id = libraryId });
        }

        var updateDto = new BookQuantityCreateDto
        {
            LibraryId = libraryId,
            BookId = bookId,
            Count = record.Count
        };
        return View(updateDto);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> EditCount(BookQuantityCreateDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateDto);
        }

        await _bookQuantityService.Update(updateDto);
        return RedirectToAction("Detail", "Library", new { id = updateDto.LibraryId });
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> RemoveBook(Guid libraryId, Guid bookId)
    {
        await _bookQuantityService.Delete(libraryId, bookId);
        return RedirectToAction("Detail", "Library", new { id = libraryId });
    }
}