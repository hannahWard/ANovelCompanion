using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels
{
    public class BookCreateViewModel
    {
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Display(Name = "Author's First Name")]
        [Required(ErrorMessage = "Author's First Name Required")]
        public string AuthorFirstName { get; set; }

        [Display(Name = "Author's Last Name")]
        [Required(ErrorMessage = "Author's Last Name Required")]
        public string AuthorLastName { get; set; }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Book book = new Book
            {
                Title = this.Title,
                AuthorFirstName = this.AuthorFirstName,
                AuthorLastName = this.AuthorLastName
            };
            repositoryFactory.GetBookRepository().Save(book);
        }
    }
}
