using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.Models
{
    public class RatingAndReview : IModel
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
        public int BookId { get; set; }
    }
}
