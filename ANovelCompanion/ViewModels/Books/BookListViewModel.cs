using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels
{
    public class BookListViewModel
    {
        public static List<BookListViewModel> GetBooks(RepositoryFactory repositoryFactory)
        {
            return repositoryFactory.GetBookRepository()
                .GetModels()
                .Select(b => new BookListViewModel(b))
                .ToList();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        [Display(Name="Average Rating")]
        public double AverageRating { get; set; }

        public BookListViewModel(Book book)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Author = book.AuthorFullName;
            if (book.Ratings.Count() == 0)
            {
                this.AverageRating = 0;
            }
            else
            {
                this.AverageRating = Math
                    .Round(book.Ratings.Average(r => r.Rating), 2);
            }
        }
    }
}
