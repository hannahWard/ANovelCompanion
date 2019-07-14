using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.Categories
{
    public class CategoryListViewModel
    {
        public static List<CategoryListViewModel> GetCategories(RepositoryFactory repositoryFactory)
        {
            return repositoryFactory.GetCategoryRepository()
                .GetModels()
                .Select(c => new CategoryListViewModel(c))
                .ToList();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryListViewModel(Category category)
        {
            this.Id = category.Id;
            this.Name = category.Name;
        }
    }
}
