using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Book_Store.Models;
using E_Book_Store.Services;
using E_Book_Store.ViewModels.EBooks;

namespace E_Book_Store.Controllers;

public class EBooksController : Controller
{
    private readonly IEBooksService EBookService;

    public EBooksController(IEBooksService eBookService)
    {
        EBookService = eBookService;
    }

    // GET: EBooks
    public IActionResult Index() => View(new EBooksIndexViewModel().FromModel(EBookService.GetAll()));

    // GET: EBooks/Details/5
    public IActionResult Details(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(new EBooksDetailsViewModel().FromModel(eBook)) : NotFound();
    }

    // GET: EBooks/Create
    public IActionResult Create() => View();

    // POST: EBooks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EBooksCreateViewModel model)
    {
        EBook eBook = model.ToModel();
        if (ModelState.IsValid)
        {
            EBookService.Create(eBook);
            return RedirectToAction(nameof(Index));
        }
        return View(eBook);
    }

    // GET: EBooks/Edit/5
    public IActionResult Edit(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(new EBooksEditViewModel().FromModel(eBook)) : NotFound();
    }

    // POST: EBooks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EBooksEditViewModel model)
    {
        EBook eBook = model.ToModel();

        if (ModelState.IsValid)
        {
            EBookService.Update(eBook);
            return RedirectToAction(nameof(Index));
        }
        return View(eBook);
    }

    // GET: EBooks/Delete/5
    public IActionResult Delete(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(new EBooksDeleteViewModel().FromModel(eBook)) : NotFound();
    }

    // POST: EBooks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(EBooksDeleteViewModel model)
    {
        EBookService.Delete(model.Id);
        return RedirectToAction(nameof(Index));
    }
}
