using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.Categories
{
    public class CategoryEditViewModel
    {
        [Required(ErrorMessage = "Category Required")]
        [Display(Name = "Category")]
        public string Name { get; set; }

        public CategoryEditViewModel() {}

        public CategoryEditViewModel(int id, RepositoryFactory repositoryFactory)
        {
            Category category = repositoryFactory.GetCategoryRepository().GetById(id);
            this.Name = category.Name;
        }

        public void Persist(int id, RepositoryFactory repositoryFactory)
        {
            Category category = new Category
            {
                Id = id,
                Name = this.Name
            };
            repositoryFactory.GetCategoryRepository().Update(category);
        }
    }
}
