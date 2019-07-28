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
    public class BookDetailsViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }

        [Display(Name = "Average Rating")]
        public double AverageRating { get; set; }

        public List<string> Categories { get; set; }

        public List<Bit> Bits { get; set; }

        public BookDetailsViewModel(int bookId, RepositoryFactory repositoryFactory)
        {
            Book book = repositoryFactory.GetBookRepository().GetById(bookId);
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
            List<string> categories = new List<string>();
            foreach (var item in book.CategoryBooks)
            {
                categories.Add(item.Category.Name);
            }
            this.Categories = categories;
            this.Bits = book.Bits;
        }
    }
}
