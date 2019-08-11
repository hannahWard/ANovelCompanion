using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANovelCompanion.Models
{
    public class Book : IModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string AuthorFullName
        {
            get { return $"{AuthorLastName}, {AuthorFirstName}"; }
        }
        public virtual List<RatingAndReview> Ratings { get; set; }
        public virtual List<CategoryBook> CategoryBooks { get; set; }
        public virtual List<Spoiler> Spoilers { get; set; }
    }
}
