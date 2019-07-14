using System;
using System.Collections.Generic;
using System.Text;
using ANovelCompanion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ANovelCompanion.Data
{
    public class NovelDbContext : IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<RatingAndReview> RatingsAndReviews { get; set; }
        public DbSet<Category> Categories { get; set; }

        public NovelDbContext(DbContextOptions<NovelDbContext> options)
            : base(options)
        {
        }

    }
}
