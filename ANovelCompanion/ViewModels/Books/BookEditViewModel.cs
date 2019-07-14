using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels
{
    public class BookEditViewModel
    {
        [Required(ErrorMessage = "Title Required")]
        public string Title { get; set; }

        [Display(Name = "Author's First Name")]
        [Required(ErrorMessage = "Author's First Name Required")]
        public string AuthorFirstName { get; set; }

        [Display(Name = "Author's Last Name")]
        [Required(ErrorMessage = "Author's Last Name Required")]
        public string AuthorLastName { get; set; }

        
        [Display(Name = "Categories")]
        public List<int> CategoryIds { get; set; }

        public List<Category> Categories { get; set; }

        public BookEditViewModel() { }

        public BookEditViewModel(int id, RepositoryFactory repositoryFactory)
        {
            Book book = repositoryFactory.GetBookRepository().GetById(id);
            this.Title = book.Title;
            this.AuthorFirstName = book.AuthorFirstName;
            this.AuthorLastName = book.AuthorLastName;
            this.Categories = repositoryFactory.GetCategoryRepository().GetModels().ToList();
            this.CategoryIds = book.CategoryBooks.Select(cb => cb.CategoryId).ToList();
        }

        public void Persist(int id, RepositoryFactory repositoryFactory)
        {
            Book book = new Book
            {
                Id = id,
                Title = this.Title,
                AuthorFirstName = this.AuthorFirstName,
                AuthorLastName = this.AuthorLastName
            };
            List<CategoryBook> categoryBooks = CreateManyToManyRelationships(book.Id, repositoryFactory);
            book.CategoryBooks = categoryBooks;
            repositoryFactory.GetBookRepository().Update(book); 
        }

        private List<CategoryBook> CreateManyToManyRelationships(int bookId, RepositoryFactory repositoryFactory)
        {
            List<CategoryBook> categoryBooks =
                repositoryFactory.GetCategoryBookRepository()
                .GetModels()
                .Where(b => b.BookId == bookId)
                .ToList();

            foreach (var item in categoryBooks)
            {
                repositoryFactory.GetCategoryBookRepository().DeleteManyToMany(item);
            }

            return CategoryIds
                .Select(catId => new CategoryBook { BookId = bookId, CategoryId = catId })
                .ToList();

        }
    }
}
