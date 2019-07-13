using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANovelCompanion.Data.Repositories;
using ANovelCompanion.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    public class BookController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public BookController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookCreateViewModel book)
        {
            book.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}