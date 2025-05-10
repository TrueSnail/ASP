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
using FluentValidation;
using FormHelper;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace E_Book_Store.Controllers;

[Authorize]
public class EBooksController : Controller
{
    private readonly IEBooksService EBookService;
    private readonly IValidator<EBook> EBookValidator;
    private readonly IMapper Mapper;

    public EBooksController(IEBooksService eBookService, IValidator<EBook> eBookValidator, IMapper mapper)
    {
        EBookService = eBookService;
        EBookValidator = eBookValidator;
        Mapper = mapper;
    }

    // GET: EBooks
    [AllowAnonymous]
    public IActionResult Index() => View(Mapper.Map<EBooksIndexViewModel>(EBookService.GetAll()));

    // GET: EBooks/Details/5
    public IActionResult Details(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(Mapper.Map<EBooksDetailsViewModel>(eBook)) : NotFound();
    }

    // GET: EBooks/Create
    public IActionResult Create() => View();

    // POST: EBooks/Create
    [HttpPost]
    [FormValidator]
    [ValidateAntiForgeryToken]
    public IActionResult Create(EBooksCreateViewModel model)
    {
        EBook eBook = Mapper.Map<EBook>(model);
        var validationResult = EBookValidator.Validate(eBook);
        if (validationResult.IsValid)
        {
            EBookService.Create(eBook);
            return RedirectToAction(nameof(Index));
        }
        return FormResult.CreateErrorResult(validationResult.Errors[0].ErrorMessage);
    }

    // GET: EBooks/Edit/5
    public IActionResult Edit(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(Mapper.Map<EBooksEditViewModel>(eBook)) : NotFound();
    }

    // POST: EBooks/Edit/5
    [HttpPost]
    [FormValidator]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(EBooksEditViewModel model)
    {
        EBook eBook = Mapper.Map<EBook>(model);

        var validationResult = EBookValidator.Validate(eBook);
        if (validationResult.IsValid)
        {
            EBookService.Update(eBook);
            return RedirectToAction(nameof(Index));
        }
        return FormResult.CreateErrorResult(validationResult.Errors[0].ErrorMessage);
    }

    // GET: EBooks/Delete/5
    public IActionResult Delete(string id)
    {
        var eBook = EBookService.GetById(id);
        return eBook != null ? View(Mapper.Map<EBooksDeleteViewModel>(eBook)) : NotFound();
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
