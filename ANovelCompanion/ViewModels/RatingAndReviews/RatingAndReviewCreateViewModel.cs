using ANovelCompanion.Data.Repositories;
using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.ViewModels.RatingAndReviews
{
    public class RatingAndReviewCreateViewModel
    {
        [Required(ErrorMessage ="Rating Required")]
        public int Rating { get; set; }

        public string Review { get; set; }
        public int BookId { get; set; }

        internal void Persist(RepositoryFactory repositoryFactory)
        {
            RatingAndReview ratingAndReview = new RatingAndReview
            {
                BookId = this.BookId,
                Rating = this.Rating,
                Review = this.Review
            };
            repositoryFactory.GetRatingAndReviewRepository()
                .Save(ratingAndReview);
        }
    }
}
