using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.Categories
{
    public class CategoryCreateViewModel
    {
        
        public string Name { get; set; }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Category category = new Category
            {
                Name = this.Name
            };
            repositoryFactory.GetCategoryRepository().Save(category);
        }
    }
}
