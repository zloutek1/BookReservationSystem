﻿using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookReservationSystem.MVC.Controllers;

public class LibraryController : Controller
{
    private readonly ILibraryService _libraryService;
    private readonly IBookQuantityService _bookQuantityService;

    public LibraryController(ILibraryService libraryService, IBookQuantityService bookQuantityService)
    {
        _libraryService = libraryService;
        _bookQuantityService = bookQuantityService;
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var libraries = await _libraryService.FindAll();
        return View(libraries);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Add()
    {
        return View();
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Add(LibraryDto createDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createDto);
        }
        
        await _libraryService.Insert(createDto);
        return RedirectToAction("Index", "Library");
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var library = await _libraryService.FindById(id);
        return View(library);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(LibraryDto updateDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateDto);
        }
        
        await _libraryService.Update(updateDto);
        return RedirectToAction("Detail", "Library", new {id = updateDto.Id});
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Detail(Guid id)
    {
        var library = await _libraryService.FindById(id);
        return View(library);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _libraryService.Delete(id);
        return RedirectToAction("Index", "Library");
    }
}