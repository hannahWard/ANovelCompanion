using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANovelCompanion.Data.Repositories;
using ANovelCompanion.ViewModels.Bits;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    public class Bit : Controller
    {
        private RepositoryFactory repositoryFactory;

        public Bit(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create(int bookId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int bookId, BitCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction("Details", "Book", new { id = bookId} );
        }
    }
}