using BookReservationSystem.BL.Exceptions;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace BookReservationSystem.MVC.Controllers;

public class LibraryController : Controller
{
    private readonly ILibraryService _libraryService;
    private readonly IToastNotification _toastNotification;

    public LibraryController(ILibraryService libraryService, IToastNotification toastNotification)
    {
        _libraryService = libraryService;
        _toastNotification = toastNotification;
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

        try
        {
            await _libraryService.Insert(createDto);
        }
        catch (ServiceException ex)
        {
            ModelState.TryAddModelError("message", "Could not add " + ex.Message);
            return View(createDto);
        }

        return RedirectToAction("Index", "Library");
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var library = await _libraryService.FindById(id);
        if (library == null)
        {
            _toastNotification.AddErrorToastMessage($"Library with id {id} not found");
            return RedirectToAction("Index", "Library");
        }
        
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

        try
        {
            await _libraryService.Update(updateDto);
        }
        catch (ServiceException ex)
        {
            ModelState.TryAddModelError("message", "Could not update: " + ex.Message);
            return View(updateDto);
        }

        return RedirectToAction("Detail", "Library", new {id = updateDto.Id});
    }
    
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Detail(Guid id)
    {
        var library = await _libraryService.FindById(id);
        if (library == null)
        {
            _toastNotification.AddErrorToastMessage($"Library with id {id} not found");
            return RedirectToAction("Index", "Library");
        }
        return View(library);
    }
    
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _libraryService.Delete(id);
        }
        catch (ServiceException ex)
        {
            _toastNotification.AddErrorToastMessage(ex.Message);
        }

        return RedirectToAction("Index", "Library");
    }
}