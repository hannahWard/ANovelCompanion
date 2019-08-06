using ANovelCompanion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.Data.Repositories
{
    public class RepositoryFactory
    {
        private NovelDbContext context;

        public RepositoryFactory(NovelDbContext context)
        {
            this.context = context;
        }

        public IRepository<Book> GetBookRepository()
        {
            return new Repository<Book>(context);
        }

        public IRepository<RatingAndReview> GetRatingAndReviewRepository()
        {
            return new Repository<RatingAndReview>(context);
        }

        public IRepository<Category> GetCategoryRepository()
        {
            return new Repository<Category>(context);
        }

        public IRepository<CategoryBook> GetCategoryBookRepository()
        {
            return new Repository<CategoryBook>(context);
        }

        public IRepository<Spoiler> GetSpoilerRepository()
        {
            return new Repository<Spoiler>(context);
        }
    }
}
