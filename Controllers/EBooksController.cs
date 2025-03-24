using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Book_Store.Data;
using E_Book_Store.Models;

namespace E_Book_Store.Controllers
{
    public class EBooksController : Controller
    {
        //private readonly EBookDbContext _context;
        private readonly IRepository<EBook> EBookRepository;

        public EBooksController(IRepository<EBook> eBookRepository)
        {
            //_context = context;
            EBookRepository = eBookRepository;
        }

        // GET: EBooks
        public IActionResult Index()
        {
            return View(EBookRepository.GetAll());
        }

        // GET: EBooks/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = EBookRepository.GetById(id);

            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // GET: EBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EBooks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Author,Title,PathToContent,Price")] EBook eBook)
        {
            if (ModelState.IsValid)
            {
                EBookRepository.Insert(eBook);
                EBookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(eBook);
        }

        // GET: EBooks/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = EBookRepository.GetById(id);

            if (eBook == null)
            {
                return NotFound();
            }
            return View(eBook);
        }

        // POST: EBooks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Author,Title,PathToContent,Price")] EBook eBook)
        {
            if (id != eBook.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    EBookRepository.Update(eBook);
                    EBookRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EBookExists(eBook.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(eBook);
        }

        // GET: EBooks/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eBook = EBookRepository.GetById(id);

            if (eBook == null)
            {
                return NotFound();
            }

            return View(eBook);
        }

        // POST: EBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var eBook = EBookRepository.GetById(id);
            if (eBook != null)
            {
                EBookRepository.Delete(id);
            }

            EBookRepository.Save();

            return RedirectToAction(nameof(Index));
        }

        private bool EBookExists(string id)
        {
            return EBookRepository.GetById(id) != null;
        }
    }
}
