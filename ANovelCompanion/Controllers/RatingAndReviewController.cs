using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANovelCompanion.Data.Repositories;
using ANovelCompanion.ViewModels.RatingAndReviews;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    [Authorize]
    public class RatingAndReviewController : Controller
    {
        private RepositoryFactory repositoryFactory;

        public RatingAndReviewController(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index(int bookId)
        {
            List<RatingAndReviewListItemViewModel> ratingsAndReviews =
                RatingAndReviewListItemViewModel.GetRatingsAndReviews(bookId, repositoryFactory);
            ViewBag.Id = bookId;
            ViewBag.Title = repositoryFactory.GetBookRepository().GetById(bookId).Title;
            return View(ratingsAndReviews);
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