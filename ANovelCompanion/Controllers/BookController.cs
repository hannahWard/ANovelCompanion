using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANovelCompanion.Data.Repositories;
using ANovelCompanion.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    public class Book : Controller
    {
        private RepositoryFactory repositoryFactory;

        public Book(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            List<BookListViewModel> books = BookListViewModel.GetBooks(repositoryFactory);
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            BookCreateViewModel model = new BookCreateViewModel(repositoryFactory);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new BookEditViewModel(id, repositoryFactory));
        }

        [HttpPost]
        public IActionResult Edit(int id, BookEditViewModel book)
        {
            if (!ModelState.IsValid)
                return View(book);

            book.Persist(id, repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            repositoryFactory.GetBookRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Details(int id)
        {
            return View(new BookDetailsViewModel(id, repositoryFactory));
        }
    }
}