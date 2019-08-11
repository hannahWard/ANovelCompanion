using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.Spoilers
{
    public class SpoilerCreateViewModel
    {
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description Required")]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        public string Image { get; set; }

        public int BookId { get; set; }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Spoiler spoiler = new Spoiler
            {
                Title = this.Title,
                Description = this.Description,
                Image = this.Image,
                BookId = this.BookId
            };
            repositoryFactory.GetSpoilerRepository().Save(spoiler);
        }


    }
}
