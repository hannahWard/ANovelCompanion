using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANovelCompanion.Data.Repositories;
using ANovelCompanion.ViewModels.RatingAndReviews;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    public class RatingAndReviewController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public RatingAndReviewController(RepositoryFactory repositoryFactory)
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
        public IActionResult Create(int bookId, RatingAndReviewCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(controllerName: nameof(Book), actionName: nameof(Index));
        }
    }
}