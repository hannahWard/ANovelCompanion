using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.RatingAndReviews
{
    public class RatingAndReviewListItemViewModel
    {
        public static List<RatingAndReviewListItemViewModel> GetRatingsAndReviews(int bookId, RepositoryFactory repositoryFactory)
        {
            return repositoryFactory
                .GetRatingAndReviewRepository()
                .GetModels()
                .Where(r => r.BookId == bookId)
                .Select(r => new RatingAndReviewListItemViewModel(r))
                .ToList();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public int Rating { get; set; }
        public string Review { get; set; }

        public RatingAndReviewListItemViewModel(RatingAndReview ratingAndReview)
        {
            this.Id = ratingAndReview.Id;
            this.Rating = ratingAndReview.Rating;
            this.Review = ratingAndReview.Review;
        }

    }
}
