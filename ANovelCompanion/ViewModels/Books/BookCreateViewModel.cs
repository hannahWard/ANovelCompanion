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
        [Display(Name = "Categories")]
        public List<int> CategoryIds { get; set; }
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Display(Name = "Author's First Name")]
        [Required(ErrorMessage = "Author's First Name Required")]
        public string AuthorFirstName { get; set; }

        [Display(Name = "Author's Last Name")]
        [Required(ErrorMessage = "Author's Last Name Required")]
        public string AuthorLastName { get; set; }

        public BookCreateViewModel() { }

        public BookCreateViewModel(RepositoryFactory repositoryFactory)
        {
            this.Categories = GetCategoryList(repositoryFactory);
        }

        public void Persist(RepositoryFactory repositoryFactory)
        {
            Book book = new Book
            {
                Title = this.Title,
                AuthorFirstName = this.AuthorFirstName,
                AuthorLastName = this.AuthorLastName
            };
            List<CategoryBook> categoryBooks = CreateManyToManyRelationships(book.Id);
            book.CategoryBooks = categoryBooks;
            repositoryFactory.GetBookRepository().Save(book);
        }

        private List<Category> GetCategoryList(RepositoryFactory repositoryFactory)
        {
            return repositoryFactory.GetCategoryRepository()
                .GetModels().ToList();
        }

        private List<CategoryBook> CreateManyToManyRelationships(int bookId)
        {
            return CategoryIds.Select(catId => new CategoryBook { BookId = bookId, CategoryId = catId }).ToList();
        }
    }
}
