using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Book_Store.Models;
using E_Book_Store.Services;

namespace E_Book_Store.Controllers;

public class EBooksController : Controller
{
    private readonly IEBooksService EBookService;

    public EBooksController(IEBooksService eBookService)
    {
        EBookService = eBookService;
    }

    // GET: EBooks
    public IActionResult Index() => View(EBookService.GetAll());

    // GET: EBooks/Details/5
    public IActionResult Details(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(eBook) : NotFound();
    }

    // GET: EBooks/Create
    public IActionResult Create() => View();

    // POST: EBooks/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Author,Title,PathToContent,Price")] EBook eBook)
    {
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
        return eBook != null ? View(eBook) : NotFound();
    }

    // POST: EBooks/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(string id, [Bind("Id,Author,Title,PathToContent,Price")] EBook eBook)
    {
        if (id != eBook.Id) return NotFound();

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
        return eBook != null ? View(eBook) : NotFound();
    }

    // POST: EBooks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(string id)
    {
        EBookService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
}
