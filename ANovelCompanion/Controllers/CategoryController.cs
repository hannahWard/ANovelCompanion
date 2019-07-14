using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ANovelCompanion.Data.Repositories;
using ANovelCompanion.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace ANovelCompanion.Controllers
{
    public class Category : Controller
    {
        private RepositoryFactory repositoryFactory;

        public Category(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public IActionResult Index()
        {
            List<CategoryListViewModel> categories = 
                CategoryListViewModel.GetCategories(repositoryFactory);

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            model.Persist(repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(new CategoryEditViewModel(id, repositoryFactory));
        }

        [HttpPost]
        public IActionResult Edit(int id, CategoryEditViewModel category)
        {
            if (!ModelState.IsValid)
                return View(category);

            category.Persist(id, repositoryFactory);
            return RedirectToAction(actionName: nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            repositoryFactory.GetCategoryRepository().Delete(id);
            return RedirectToAction(actionName: nameof(Index));
        }

    }
}